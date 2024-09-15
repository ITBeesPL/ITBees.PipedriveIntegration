using ITBees.Interfaces.Platforms;
using ITBees.PipedriveIntegration.Models;
using Newtonsoft.Json;
using System.Text;
using ITBees.PipedriveIntegration.Interfaces;

namespace ITBees.PipedriveIntegration.Services;

public class PipedriveConnectorService : IPipedriveConnectorService
{
    private readonly IPlatformSettingsService _platformSettingsService;
    private readonly string apiUrl;
    private readonly string apiToken;
    private int personId;
    private readonly int organizationId;

    public PipedriveConnectorService(IPlatformSettingsService platformSettingsService)
    {
        _platformSettingsService = platformSettingsService;
        apiToken = _platformSettingsService.GetSetting("pipedrive_api_token");
        apiUrl = _platformSettingsService.GetSetting("pipedrive_api_url");
        personId = Convert.ToInt32(_platformSettingsService.GetSetting("pipedrive_default_person_owner_id"));
        organizationId = Convert.ToInt32(_platformSettingsService.GetSetting("pipedrive_organization_id"));
        if (string.IsNullOrEmpty(apiUrl) || string.IsNullOrEmpty(apiToken))
        {
            throw new Exception("pipedrive_api_token and pipedrive_api_url must be set in config file");
        }
    }

    public async Task<List<User>> GetUsers()
    {
        using (HttpClient client = new HttpClient())
        {
            string requestUrl = $"{apiUrl}?api_token={apiToken}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var pipedriveResponse = JsonConvert.DeserializeObject<PipedriveResponse<List<User>>>(responseBody);

                    if (pipedriveResponse.Success)
                    {
                        var employees = pipedriveResponse.Data.Where(user => user.ActiveFlag).ToList();

                        return employees;
                    }
                    else
                    {
                        throw new Exception("Request failed");
                    }
                }
                else
                {
                    throw new Exception("Request failed");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public async Task<LeadResponse> AddNewLead(string leadTitle, string note)
    {
        
        if (personId == 0)
        {
            var first = (await GetUsers()).First();
            personId = first.Id;
        }

        var leadRequest = new LeadRequest
        {
            Title = leadTitle,
            PersonId = personId,
            OrganizationId = organizationId,
            Note = note
        };

        using (HttpClient client = new HttpClient())
        {
            string requestUrl = $"{apiUrl}?api_token={apiToken}";

            string jsonLead = JsonConvert.SerializeObject(leadRequest);
            StringContent content = new StringContent(jsonLead, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var leadResponse = JsonConvert.DeserializeObject<LeadResponse>(responseBody);

                    if (leadResponse.Success)
                    {
                        return leadResponse;
                    }
                    else
                    {
                        throw new Exception("Unable to create new lead");
                    }
                }
                else
                {
                    throw new Exception($"Unable to create new lead {response.StatusCode}, {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}