using System.Text.Json.Serialization;
using Securely.net.Converters;
using Securely.Subscriptions.Types;

namespace Securely.Subscriptions.Requests;

/// <summary>
/// Represents a request to create a subscription, including details such as customer information,  subscription terms,
/// and optional metadata.
/// </summary>
/// <remarks>This class is used to encapsulate all the necessary information required to create a subscription. 
/// It includes required fields such as the customer ID, amount, and subscription frequency, as well as  optional fields
/// like internal notes and an external identifier. Ensure all required fields are  populated before submitting the
/// request.</remarks>
public class CreateSubscriptionRequest
{
    /// <summary>
    /// Description to keep track of subscription requests.
    /// Required. Length between 1 and 24.
    /// </summary>
    public string Memo { get; set; } = string.Empty;

    /// <summary>
    /// Message to the customer that is included when viewing the subscription request.
    /// Required. Length between 1 and 2500.
    /// </summary>
    public string CustomerMessage { get; set; } = string.Empty;

    /// <summary>
    /// Securely customer id to create the subscription request for.
    /// Required. 1 to 2147483647.
    /// </summary>
    public int CustomerUserId { get; set; }

    /// <summary>
    /// Internal notes for the subscription request, not viewable to the customer.
    /// Length ≤ 250.
    /// </summary>
    public string? InternalNotes { get; set; }

    /// <summary>
    /// Invoice number from the api consumer system to help identify the subscription request.
    /// Required. Length ≥ 1.
    /// </summary>
    public string InvoiceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Amount for the subscription (>= $0.01).
    /// Required. ≥ 0.01.
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// File to be attached to the subscription request, visible to the customer.
    /// </summary>
    public object? Attachment { get; set; }

    /// <summary>
    /// Subscription cycle desc (WEEKLY, EVERY OTHER WEEK, BIMONTHLY(1st and 15th), MONTHLY, QUARTERLY, YEARLY)
    /// </summary>
    [JsonConverter(typeof(FrequencyConverter))]
    public Frequency Frequency { get; set; } = Frequency.Monthly;

    /// <summary>
    /// Subscription end date
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Subscription start date
    /// </summary>
    public DateTime EffectiveDate { get; set; }

    /// <summary>
    /// Indicates if an email/text should be sent to the customer informing them when subscription payment request is sent.
    /// </summary>
    public bool SendPaymentReminders { get; set; }

    /// <summary>
    /// Indicates if an email/text should be sent to the customer informing them when a payment has completed. Default is true.
    /// </summary>
    public bool SendReceipt { get; set; } = true;

    /// <summary>
    /// Indicates if an email/text should be sent to the customer informing them about the subscription. Default is true.
    /// </summary>
    public bool SendNotice { get; set; } = true;

    /// <summary>
    /// Primary/Customer assigned plan used by default if not supplied.
    /// </summary>
    public int? AlternatePricingPlanId { get; set; }

    /// <summary>
    /// External identifier for subscription request. Expected to be a unique identifier from the API consumer's system.
    /// Length ≤ 250.
    /// </summary>
    public string? ExternalIdentifier { get; set; }
}
