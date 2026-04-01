namespace Securely.Entities;

/// <summary>
/// Error information in the case that the request was unsuccessful
/// </summary>
public class BaseResponseError {
    /// <summary>
    /// Error Code
    /// </summary>
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Message that should be displayed to the user
    /// </summary>
    public string? ErrorDisplayMessage { get; set; }

    /// <summary>
    /// Other error information
    /// </summary>
    public Dictionary<string, string> ErrorData { get; set; } = new();

    /// <summary>
    /// Indicates to the caller that the call may be retried with given input parameters
    /// </summary>
    public bool IsRetryable { get; set; }
}
