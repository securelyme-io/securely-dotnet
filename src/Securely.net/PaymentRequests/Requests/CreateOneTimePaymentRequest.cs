namespace Securely.net.PaymentRequests.Requests;

/// <summary>
/// Request to create a one-time payment request in Securely.
/// </summary>
public class CreateOneTimePaymentRequest {
    /// <summary>
    /// Invoice amount for the payment request (>= $0.01).
    /// Required.
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Message to the customer that is included when viewing the payment request.
    /// Required. Length between 1 and 2500.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Invoice number from the API consumer's system to help identify the payment request.
    /// Required. Length >= 1.
    /// </summary>
    public string InvoiceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Securely customer id to create the payment request for.
    /// Required.
    /// </summary>
    public int CustomerUserId { get; set; }

    /// <summary>
    /// Internal notes for the payment request, not viewable to the customer.
    /// Optional. Max length 250.
    /// </summary>
    public string? InternalNotes { get; set; }

    /// <summary>
    /// External identifier for payment request. Expected to be a unique identifier from the API consumer's system.
    /// Optional.
    /// </summary>
    public string? ExternalIdentifier { get; set; }

    /// <summary>
    /// File to be attached to the payment request, visible to the customer.
    /// Optional.
    /// </summary>
    public PaymentRequestAttachment? Attachment { get; set; }

    /// <summary>
    /// Alternate pricing plan ID to use for processing fees.
    /// Optional.
    /// </summary>
    public int? AlternatePricingPlanId { get; set; }

    /// <summary>
    /// Indicates if an email/text should be sent to the customer informing them of the payment request.
    /// Default is true.
    /// </summary>
    public bool SendNotice { get; set; } = true;

    /// <summary>
    /// Indicates if an email/text should be sent to the customer after successful payment.
    /// Default is true.
    /// </summary>
    public bool SendReceipt { get; set; } = true;

    /// <summary>
    /// Terminal serial number if associated with a terminal.
    /// Optional.
    /// </summary>
    public string? TerminalSerialNumber { get; set; }

    /// <summary>
    /// Reference identifier for the payment request (UUID format).
    /// Optional.
    /// </summary>
    public string? PaymentRequestReference { get; set; }
}

/// <summary>
/// File attachment for a payment request.
/// </summary>
public class PaymentRequestAttachment {
    /// <summary>
    /// The file name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The base64-encoded file content.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// The MIME type of the file (e.g., "application/pdf").
    /// </summary>
    public string MimeType { get; set; } = string.Empty;
}
