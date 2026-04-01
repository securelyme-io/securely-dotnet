using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace Securely.net.PaymentRequests.Responses;

/// <summary>
/// A transaction object connected to a payment request
/// </summary>
public class TransactionResponse {
    /// <summary>
    /// Transaction id prefixed with pc_ or dc_ based on type
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Transaction type is either PC for payment card or DC for digital cash
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// True if transaction is a refund
    /// </summary>
    public bool IsRefund { get; set; }

    /// <summary>
    /// Amount of transaction
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// If DC brand will be DIGITAL_CASH, if PC brand will be credit card brand
    /// </summary>
    public string? Brand { get; set; }

    /// <summary>
    /// Last four digits of card number or bank account
    /// </summary>
    public string? LastFour { get; set; }

    /// <summary>
    /// Expiration date if payment was PC
    /// </summary>
    public string? ExpireDate { get; set; }

    /// <summary>
    /// Auth code is populated if PC
    /// </summary>
    public string? AuthCode { get; set; }

    /// <summary>
    /// Current status of transaction
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Securely.net.PaymentRequests.Enum.TransactionStatus Status { get; set; }

    /// <summary>
    /// Date of update to current status
    /// </summary>
    public DateTime StatusDate { get; set; }

    /// <summary>
    /// Date transaction created
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Merchant batch transfer id if the transaction has been batched
    /// </summary>
    public int? MerchantBatchTransferId { get; set; }

    /// <summary>
    /// Merchant batch transfer set id if the transaction has been batched
    /// </summary>
    public int? MerchantBatchTransferSetId { get; set; }

    /// <summary>
    /// An external identifier for the transaction
    /// </summary>
    public string? ExternalIdentifier { get; set; }
}
