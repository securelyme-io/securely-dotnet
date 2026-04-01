using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Securely.Customers.Responses;
using Securely.net.PaymentRequests.Enum;

namespace Securely.net.PaymentRequests.Responses;

/// <summary>
/// A payment request is an object that represents a request for payment from a customer.
/// </summary>
public class PaymentRequestResponse {
    /// <summary>
    /// Securely payment request id.
    /// </summary>
    public long PaymentRequestId { get; set; }

    /// <summary>
    /// External identifier for payment request. Expected to be a unique identifier from the API consumer's system.
    /// </summary>
    public string? ExternalIdentifier { get; set; }

    /// <summary>
    /// The status of the payment request
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PaymentRequestStatusCode StatusCode { get; set; }

    /// <summary>
    /// Customer object.
    /// </summary>
    public CustomerResponse? Customer { get; set; }

    /// <summary>
    /// Invoice amount for the payment request (>= $0.01).
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Tip amount for the payment request (>= $0.00).
    /// </summary>
    public double TipAmount { get; set; }

    /// <summary>
    /// Total amount paid for the payment request based on the payment method (>= $0.01).
    /// </summary>
    public double TotalAmount { get ;set;}

    /// <summary>
    /// Message to the customer that is included when viewing the payment request.
    /// </summary>
    public string? Message { get ;set;}

    /// <summary>
    /// Internal notes for the payment request, not viewable to the customer.
    /// </summary>
    public string? InternalNotes { get; set; }

    /// <summary>
    /// Invoice number from the api consumer system to help identify the payment request.
    /// </summary>
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// When the payment request was created.
    /// </summary>
    public DateTime CreatedDate { get ;set;}

    /// <summary>
    /// When the payment request was completed.
    /// </summary>
    public DateTime? CompletedDate { get ;set;}

    /// <summary>
    /// Pricing Plan Id.
    /// </summary>
    public int PricingPlanId { get; set; }

    /// <summary>
    /// Pricing Plan Name.
    /// </summary>
    public string PricingPlanName { get; set;} = string.Empty;

    /// <summary>
    /// Payment Request Reference Guid.
    /// </summary>
    public string PaymentRequestReference { get; set;} = string.Empty;

    /// <summary>
    /// The type of payment
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PaymentTypeCode PaymentTypeCode { get; set; }

    /// <summary>
    /// Opetional terminal ID that was used when the payment request was created
    /// </summary>
    public int? TerminalId { get ;set; }

    /// <summary>
    /// Array of transactions that make up the payment request
    /// </summary>
    public List<TransactionResponse> Transactions { get; set; } = new List<TransactionResponse>();

}
