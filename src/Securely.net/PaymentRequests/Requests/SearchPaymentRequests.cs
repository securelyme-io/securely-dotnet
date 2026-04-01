using Securely.net.PaymentRequests.Enum;
using System.Text.Json.Serialization;

namespace Securely.net.PaymentRequests.Requests;

/// <summary>
/// Object to provide the criteria to search payment requests.
/// </summary>
public class SearchPaymentRequests {
    /// <summary>
    /// External identifier for payment request. Expected to be a unique identifier from the API consumer's system.
    /// </summary>
    public string? ExternalIdentifier { get; set; }

    /// <summary>
    /// Starting date range to search for payment requests by created date.
    /// </summary>
    public DateTimeOffset? CreatedFromDate { get; set; }

    /// <summary>
    /// Ending date range to search for payment requests by created date.
    /// </summary>
    public DateTimeOffset? CreatedToDate { get; set; }

    /// <summary>
    /// Invoice number of payment request.
    /// </summary>
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// List of payment request statuses to include in the search (SENT, VIEWED, DELETED, CANCELLED, PAYMENTREJECTED, ERROR, PAID, PENDINGREFUND, REFUNDED, ACCEPTED, EXPIRED, PARTIALREFUND, PASTDUE).
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public List<PaymentRequestStatusCode>? StatusCodes { get; set; }

    /// <summary>
    /// List of payment request type to include in the search (ONETIME, RECURRING, TERMINAL, QUICKPAY).
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public List<PaymentTypeCode>? Types { get; set; }

    /// <summary>
    /// Id of customer associated to payment request. Searches on customer id will ignore other customer searches (first name, last name, company name, email, phone and account number).
    /// </summary>
    public int? CustomerId { get; set; }

    /// <summary>
    /// External identifier for consumer. Expected to be a unique identifier from the API consumer's system.
    /// </summary>
    public string? CustomerExternalIdentifier { get; set; }

    /// <summary>
    /// First name of customer associated to payment request.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Last name of customer associated to payment request.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Company name of customer associated to payment request.
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// Email of customer associated to payment request.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Cell phone of customer associated to payment request.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Account number of customer associated to payment request.
    /// </summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Number of payment requests to return per page. 1 to 100. Defaults to 20.
    /// </summary>
    public int PageSize { get; set; } = 20;

    /// <summary>
    /// Which page of the results set. Starts with page 1. 1 to 2147483647. Defaults to 1.
    /// </summary>
    public int Page { get; set; } = 1;
}