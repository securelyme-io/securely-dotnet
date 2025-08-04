using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Securely.Entities;
using Securely.JsonConverters;
using Securely.net.Entities;

namespace Securely;

/// <summary>
/// Base service to actually send the request to Securely and secure the response
/// </summary>
public class SecurelyService
{
    private readonly string _apiKey;
    private readonly string _apiSecret;
    private readonly string _apiUrl;

    /// <summary>
    /// Create a service to communicate with the Securelty API
    /// </summary>
    /// <param name="apiKey">The api key that you get from the merchant settings</param>
    /// <param name="apiSecret">The api secret you get from the merchant settings</param>
    /// <param name="isSandbox">Determining if the url should be the sandbox or production</param>
    public SecurelyService(string apiKey, string apiSecret, bool isSandbox)
    {
        _apiKey = apiKey;
        _apiSecret = apiSecret;
        _apiUrl = isSandbox ? "https://sandbox.securelyme.io" : "https://api.securelyme.io";
    }
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        PropertyNameCaseInsensitive = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        Converters = { new StringConverter(), new DateTimeConverter() },
    };

    /// <summary>
    /// Execute a get request to the Securely API with a url suffix.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="urlSuffix"></param>
    /// <returns></returns>
    public async Task<ISecurelyResponse<TResult?>> ExecuteAsync<TResult>(string urlSuffix)
        where TResult : new()
    {
        using var http = GetHttpClient();
        var response = await http.GetAsync(urlSuffix);
        return await ConvertResponseAsync<TResult>(response);
    }

    /// <summary>
    /// Execute a post request to the Securely API with a request object and a url suffix.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="request"></param>
    /// <param name="urlSuffix"></param>
    /// <returns></returns>
    public async Task<ISecurelyResponse<TResult?>> ExecuteAsync<TEntity, TResult>(TEntity request, string urlSuffix)
        where TEntity : new()
        where TResult : new()
    {
        var json = JsonSerializer.Serialize(request, _jsonSerializerOptions);

        using var http = GetHttpClient();
        var response = await http.PostAsync(urlSuffix, new StringContent(json, Encoding.UTF8, "application/json"));
        return await ConvertResponseAsync<TResult>(response);
    }

    private async Task<ISecurelyResponse<TEntity?>> ConvertResponseAsync<TEntity>(HttpResponseMessage response) where TEntity : new()
    {
        var integrationResponse = new SecurelyResponse<TEntity?>
        {
            StatusCode = response.StatusCode,
            RawResponse = await response.Content.ReadAsStringAsync(),
            Url = response.RequestMessage?.RequestUri?.ToString(),
            RawRequest = response.RequestMessage?.Content is not null
                ? await response.RequestMessage.Content.ReadAsStringAsync()
                : null,
        };
        integrationResponse.Data = JsonSerializer.Deserialize<BaseResponse<TEntity?>>(integrationResponse.RawResponse) ?? new BaseResponse<TEntity?>();

        return integrationResponse;
    }

    private HttpClient GetHttpClient()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(this._apiUrl)
        };
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_apiKey}:{_apiSecret}")));
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("SeucerlyPOS/1.0.0");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return httpClient;
    }
}
