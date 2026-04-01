using System.Net;

namespace Securely.Entities;

/// <summary>
/// A generic response for all requests made.
/// </summary>
public interface ISecurelyResponse {
    /// <summary>
    /// The value passed to the api endpoint as the request
    /// </summary>
    string? RawRequest { get; set; }

    /// <summary>
    /// The raw response of the request from the api endpoint
    /// </summary>
    string? RawResponse { get; set; }

    /// <summary>
    /// The url that was called for the endpoint
    /// </summary>
    string? Url { get; set; }

    /// <summary>
    /// The response status code from the request
    /// </summary>
    HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Was the request successful, this is determined from the StatusCode
    /// </summary>
    bool IsSuccessful { get; }

    /// <summary>
    /// Any headers that are returned from the response
    /// </summary>
    public string? Headers { get; set; }
}

/// <summary>
/// A generic response for all requests made.
/// </summary>
/// <typeparam name="TData">The full response container type (e.g., BaseResponse&lt;Customer&gt; or PagedResponse&lt;Transaction&gt;)</typeparam>
public interface ISecurelyResponse<TData> : ISecurelyResponse {
    /// <summary>
    /// If there is data that was returned from the request, it will be serialized to this entity
    /// </summary>
    TData Data { get; set; }
}

/// <summary>
/// A generic response for all requests made.
/// </summary>
public class SecurelyResponse : ISecurelyResponse {
    /// <summary>
    /// The raw request in JSON format that was sent to the api
    /// </summary>
    public string? RawRequest { get; set; }

    /// <summary>
    /// The raw body response in JSON format that was returned from the api
    /// </summary>
    public string? RawResponse { get; set; }

    /// <summary>
    /// The full url that was called for the endpoint
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// The HTTP Status Code returned from the request
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Any headers that are returned from the response
    /// </summary>
    public string? Headers { get; set; }

    /// <summary>
    /// Determines if the request was successful based on the StatusCode
    /// </summary>
    public bool IsSuccessful => (int)StatusCode >= 200 && (int)StatusCode < 300;
}

/// <summary>
/// A generic response for all requests made.
/// </summary>
/// <typeparam name="TData">The full response container type (e.g., BaseResponse&lt;Customer&gt; or PagedResponse&lt;Transaction&gt;)</typeparam>
public class SecurelyResponse<TData> : SecurelyResponse, ISecurelyResponse<TData> where TData : new() {
    /// <summary>
    /// If there is data that was returned from the request, it will be serialized to this entity
    /// </summary>
    public TData Data { get; set; } = new TData();
}
