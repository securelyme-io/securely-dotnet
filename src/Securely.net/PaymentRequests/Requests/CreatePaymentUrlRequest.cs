namespace Securely.net.PaymentRequests.Requests;

/// <summary>
/// Request to create a URL for a payment request in Securely.
/// </summary>
public class CreatePaymentUrlRequest {
    /// <summary>
    /// An optional URL to redirect the customer to after a successful payment.
    /// </summary>
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// An optional message to display to the customer after successful payment.
    /// </summary>
    public string? ConfirmationMessage { get; set; }

    /// <summary>
    /// Optional text for the confirmation button after successful payment.
    /// Defaults to "Continue".
    /// </summary>
    public string? ContinueButtonText { get; set; }

    /// <summary>
    /// Optional UTC date indicating when the URL should expire.
    /// </summary>
    public DateTime? ExpiresOn { get; set; }
}
