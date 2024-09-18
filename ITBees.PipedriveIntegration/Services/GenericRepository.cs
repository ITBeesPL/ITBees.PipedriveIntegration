namespace ITBees.PipedriveIntegration.Services;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class GenericRepository
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;
    private readonly string _apiToken;

    private readonly JsonSerializerSettings _postSettings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };

    private readonly JsonSerializerSettings _getSettings = new JsonSerializerSettings
    {
        MissingMemberHandling = MissingMemberHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore
    };

    public GenericRepository(string apiUrl, string apiToken)
    {
        _httpClient = new HttpClient();
        _apiUrl = apiUrl;
        _apiToken = apiToken;
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data, string endpointParameters = null)
    {
        AddEndpointParameters(ref endpointParameters);
        var requestUrl = $"{_apiUrl}/{endpoint}?api_token={_apiToken}{endpointParameters}";
        var jsonData = JsonConvert.SerializeObject(data, _postSettings);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync(requestUrl, content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseBody);
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"HTTP Request Error: {ex.Message}");
        }
    }

    private void AddEndpointParameters(ref string endpointParameters)
    {
        if (string.IsNullOrEmpty(endpointParameters) == false)
        {
            endpointParameters = "&" + endpointParameters;
        }
    }

    public async Task<TResponse> GetAsync<TResponse>(string endpoint, string endpointParameters = null)
    {
        AddEndpointParameters(ref endpointParameters);
        var requestUrl = $"{_apiUrl}/{endpoint}?api_token={_apiToken}{endpointParameters}";

        try
        {
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseBody, _getSettings);
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"HTTP Request Error: {ex.Message}");
        }
    }
}
