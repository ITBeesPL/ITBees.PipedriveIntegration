using ITBees.Interfaces.Platforms;
using ITBees.PipedriveIntegration.Models;
using ITBees.Interfaces.ExternalSalesPlatformIntegration;
using ITBees.Interfaces.ExternalSalesPlatformIntegration.Models;
using ITBees.PipedriveIntegration.Interfaces;

namespace ITBees.PipedriveIntegration.Services
{
    public class PipedriveConnectorService : IPipedriveConnectorService, INewPipedriveLeadService, INewExternalSalesPlatformIntegrationService
    {
        private readonly IPlatformSettingsService _platformSettingsService;
        private readonly GenericRepository _repository;
        private int personId;
        private readonly int organizationId;

        public PipedriveConnectorService(IPlatformSettingsService platformSettingsService)
        {
            _platformSettingsService = platformSettingsService;
            var apiToken = _platformSettingsService.GetSetting("pipedrive_api_token");
            var apiUrl = _platformSettingsService.GetSetting("pipedrive_api_url");
            personId = Convert.ToInt32(_platformSettingsService.GetSetting("pipedrive_default_person_owner_id"));
            organizationId = Convert.ToInt32(_platformSettingsService.GetSetting("pipedrive_organization_id"));

            if (string.IsNullOrEmpty(apiUrl) || string.IsNullOrEmpty(apiToken))
            {
                throw new Exception("pipedrive_api_token and pipedrive_api_url must be set in config file");
            }

            _repository = new GenericRepository(apiUrl, apiToken);
        }

        public async Task<List<Person>> GetUsers()
        {
            var response = await _repository.GetAsync<ApiResponse>("persons/");

            if (response.Success)
            {
                return response.Data;
            }
            else
            {
                throw new Exception("Request failed");
            }
        }

        public async Task<PipedriveResponse<PersonData>> CreatePerson(string name, string email, string phone)
        {
            var newPerson = new PersonRequest
            {
                Name = name,
                Email = new List<EmailField>
                {
                    new EmailField { Label = "email", Value = email, Primary = true }
                },
                Phone = new List<PhoneField>
                {
                    new PhoneField { Label = "tel", Value = phone, Primary = true }
                }
            };

            var personResponse = await _repository.PostAsync<PersonRequest, PipedriveResponse<PersonData>>("persons", newPerson);

            if (personResponse.Success)
            {
                return personResponse;
            }
            else
            {
                throw new Exception("Could not create person in Pipedrive API");
            }
        }

        public async Task<NewLeadCreateResultVm> CreateLead(NewLeadIm newLeadIm)
        {
            var createdPerson = await CreatePerson(newLeadIm.Name, newLeadIm.Email, newLeadIm.Phone);
            List<Guid> labelGuids = new List<Guid>();
            if (string.IsNullOrEmpty(newLeadIm.Label) == false)
            {
                labelGuids.Add(await GetLabelGuid(newLeadIm.Label, newLeadIm.LabelColor));
            }

            if (newLeadIm.NIP != null || newLeadIm.CompanyName != null)
            {

            }

            var newOrganization = new NewOrganization();
            var organization = await _repository.PostAsync<NewOrganization, NewOrganizationResponse>("/organization", newOrganization);

            var leadRequest = new NewLeadRequest()
            {
                Title = $"{newLeadIm.Campaign} {newLeadIm.Name}",
                PersonId = createdPerson.Data.Id,
                Value = new LeadValue() { Amount = newLeadIm.PossibleValue.Value, Currency = newLeadIm.PossibleValueCurrency },
                LabelIds = labelGuids,
                OrganizationId = organizationId,
                SourceName = newLeadIm.SourceUrl,
                Email = newLeadIm.Email,
            };

            var leadResponse = await _repository.PostAsync<NewLeadRequest, LeadResponse>("leads/", leadRequest);

            if (leadResponse.Success)
            {
                return new NewLeadCreateResultVm() { Success = true };
            }
            else
            {
                return new NewLeadCreateResultVm() { Success = false, Message = "Unable to create new lead" };
            }
        }

        public string? SourceName { get; set; }

        public async Task<LabelResponse> GetLabels()
        {
            var labels = await _repository.GetAsync<LabelResponse>("/labels");

            if (labels.Success)
            {
                return labels;
            }
            else
            {
                throw new Exception("Unable to get labels");
            }
        }

        public async Task<Guid> GetLabelGuid(string labelName, string? labelColor)
        {
            var labels = await GetLabels();
            var firstLableWithName = labels.Data.FirstOrDefault(x => x.Name == labelName);
            if (firstLableWithName == null)
            {
                var label = new NewLabel() { Color = labelColor, Name = labelName };
                var createdLabel = await _repository.PostAsync<NewLabel, NewLabelResponse>("/leadLabels", label);
                return createdLabel.Data.Id;
            }

            return firstLableWithName.Id;
        }
    }

    public class NewOrganizationResponse
    {
    }

    public class NewOrganization
    {
    }
}
