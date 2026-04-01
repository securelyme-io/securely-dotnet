namespace Securely.Entities;
/// <summary>
/// Represents a response from the Api
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public class BaseResponse<TResponse> : BaseResponse {
    /// <summary>
    /// Contains the response data for the request.
    /// </summary>
    public TResponse? Payload { get; set; }
}

/// <summary>
/// Represents a response from the Api
/// </summary>
public class BaseResponse {
    /// <summary>
    /// A unique identifier assigned to request
    /// </summary>
    public string? CorrelationId { get; set; }

    /// <summary>
    /// Whether or not the request was successful
    /// </summary>
    public bool Success => Error == null;

    /// <summary>
    /// Error information in the case that the request was unsuccessful
    /// </summary>
    public BaseResponseError? Error { get; set; }
}