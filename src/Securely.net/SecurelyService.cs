using Microsoft.Extensions.Options;
using Securely.Entities;
using Securely.JsonConverters;
using Securely.net.Entities;
using Securely.net.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Securely;

/// <summary>
/// Service for making requests to the Securely API
/// </summary>
public interface ISecurelyService {
    /// <summary>
    /// Execute a GET request to the Securely API
    /// </summary>
    /// <typeparam name="TData">The full response container type (e.g., BaseResponse&lt;Customer&gt; or PagedResponse&lt;Transaction&gt;)</typeparam>
    /// <param name="apiKey">The API key</param>
    /// <param name="apiSecret">The API secret</param>
    /// <param name="urlSuffix">The URL suffix for the endpoint</param>
    /// <returns>The response from the API</returns>
    Task<ISecurelyResponse<TData>> ExecuteAsync<TData>(string apiKey, string apiSecret, string urlSuffix)
        where TData : new();

    /// <summary>
    /// Execute a POST request to the Securely API
    /// </summary>
    /// <typeparam name="TRequest">The request entity type</typeparam>
    /// <typeparam name="TData">The full response container type (e.g., BaseResponse&lt;Customer&gt; or PagedResponse&lt;Transaction&gt;)</typeparam>
    /// <param name="request">The request payload</param>
    /// <param name="apiKey">The API key</param>
    /// <param name="apiSecret">The API secret</param>
    /// <param name="urlSuffix">The URL suffix for the endpoint</param>
    /// <returns>The response from the API</returns>
    Task<ISecurelyResponse<TData>> ExecuteAsync<TRequest, TData>(TRequest request, string apiKey, string apiSecret, string urlSuffix)
        where TRequest : new()
        where TData : new();
}

/// <summary>
/// 
/// </summary>
public class SecurelyService : ISecurelyService {
    private readonly SecurelyOptions _options;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        PropertyNameCaseInsensitive = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        Converters = { new StringConverter(), new DateTimeConverter() },
    };

    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="httpClientFactory"></param>
    public SecurelyService(IOptions<SecurelyOptions> options, IHttpClientFactory httpClientFactory) {
        _options = options.Value;
        _httpClientFactory = httpClientFactory;
    }

    /// <inheritdoc />
    public async Task<ISecurelyResponse<TData>> ExecuteAsync<TData>(string apiKey, string apiSecret, string urlSuffix)
        where TData : new() {
        using var http = CreateHttpClient(apiKey, apiSecret);
        var response = await http.GetAsync(urlSuffix);
        return await ConvertResponseAsync<TData>(response);
    }

    /// <inheritdoc />
    public async Task<ISecurelyResponse<TData>> ExecuteAsync<TRequest, TData>(TRequest request, string apiKey, string apiSecret, string urlSuffix)
        where TRequest : new()
        where TData : new() {
        var json = JsonSerializer.Serialize(request, _jsonSerializerOptions);
        using var http = CreateHttpClient(apiKey, apiSecret);
        var response = await http.PostAsync(urlSuffix, new StringContent(json, Encoding.UTF8, "application/json"));
        return await ConvertResponseAsync<TData>(response);
    }

    private async Task<ISecurelyResponse<TData>> ConvertResponseAsync<TData>(HttpResponseMessage response) where TData : new() {
        var integrationResponse = new SecurelyResponse<TData> {
            StatusCode = response.StatusCode,
            RawResponse = await response.Content.ReadAsStringAsync(),
            Url = response.RequestMessage?.RequestUri?.ToString(),
            RawRequest = response.RequestMessage?.Content is not null
                ? await response.RequestMessage.Content.ReadAsStringAsync()
                : null,
        };

        integrationResponse.Data = JsonSerializer.Deserialize<TData>(integrationResponse.RawResponse, _jsonSerializerOptions)
                                   ?? new TData();

        return integrationResponse;
    }

    private HttpClient CreateHttpClient(string apiKey, string apiSecret) {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_options.UseSandbox
            ? "https://sandbox-api.securelyme.io"
            : "https://api.securelyme.io");

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:{apiSecret}")));
        client.DefaultRequestHeaders.UserAgent.ParseAdd("SecurelyPOS/1.0.0");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return client;
    }
}