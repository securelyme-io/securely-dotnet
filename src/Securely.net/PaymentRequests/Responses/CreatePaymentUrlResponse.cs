using System.Text.Json.Serialization;

namespace Securely.net.PaymentRequests.Responses;

/// <summary>
/// Response from creating a payment request URL.
/// </summary>
public class CreatePaymentUrlResponse {
    /// <summary>
    /// The redirect URL configured for after payment completion.
    /// </summary>
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// The text for the continue button.
    /// </summary>
    public string? ContinueButtonText { get; set; }

    /// <summary>
    /// The confirmation message displayed after payment.
    /// </summary>
    public string? ConfirmationMessage { get; set; }

    /// <summary>
    /// The absolute URL for the payment page.
    /// This is the URL to send the customer to for payment.
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Context value for the short URL.
    /// </summary>
    public int ContextValue { get; set; }

    /// <summary>
    /// The type of short URL.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ShortUrlType ShortUrlType { get; set; }

    /// <summary>
    /// The authorization type for the short URL.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ShortUrlAuthorizationType ShortUrlAuthorizationType { get; set; }

    /// <summary>
    /// When the URL expires.
    /// </summary>
    public DateTime? ExpiresOn { get; set; }
}

/// <summary>
/// Type of short URL.
/// </summary>
public enum ShortUrlType {
    /// <summary>
    /// Unknown type.
    /// </summary>
    Unknown,

    /// <summary>
    /// Payment request URL.
    /// </summary>
    PaymentRequest,

    /// <summary>
    /// Subscription URL.
    /// </summary>
    Subscription
}

/// <summary>
/// Authorization type for short URL.
/// </summary>
public enum ShortUrlAuthorizationType {
    /// <summary>
    /// No authorization required.
    /// </summary>
    None,

    /// <summary>
    /// PIN authorization required.
    /// </summary>
    Pin,

    /// <summary>
    /// Token authorization required.
    /// </summary>
    VALIDATIONCODE
}
