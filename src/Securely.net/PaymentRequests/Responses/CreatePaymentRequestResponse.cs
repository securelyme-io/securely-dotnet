namespace Securely.net.PaymentRequests.Responses;

/// <summary>
/// Response from creating a one-time payment request.
/// </summary>
public class CreatePaymentRequestResponse {
    /// <summary>
    /// The ID of the newly created payment request.
    /// </summary>
    public long PaymentRequestId { get; set; }
}
