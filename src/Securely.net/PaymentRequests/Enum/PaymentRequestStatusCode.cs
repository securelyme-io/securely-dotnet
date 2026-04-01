using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securely.net.PaymentRequests.Enum;

/// <summary>
/// Payment request status
/// </summary>
public enum PaymentRequestStatusCode {
    /// <summary>
    /// The payment request has been sent to the recipient.
    /// </summary>
    SENT,
    /// <summary>
    /// The payment request has been viewed by the recipient.
    /// </summary>
    VIEWED,
    /// <summary>
    /// The payment request has been deleted.
    /// </summary>
    DELETED,
    /// <summary>
    /// The payment request has been cancelled by the sender or system.
    /// </summary>
    CANCELLED,
    /// <summary>
    /// The payment request was rejected by the payer.
    /// </summary>
    PAYMENTREJECTED,
    /// <summary>
    /// An error occurred with the payment request.
    /// </summary>
    ERROR,
    /// <summary>
    /// The payment request has been paid in full.
    /// </summary>
    PAID,
    /// <summary>
    /// The payment request is pending a refund.
    /// </summary>
    PENDINGREFUND,
    /// <summary>
    /// The payment request has been refunded.
    /// </summary>
    REFUNDED,
    /// <summary>
    /// The payment request has been accepted by the payer.
    /// </summary>
    ACCEPTED,
    /// <summary>
    /// The payment request has expired.
    /// </summary>
    EXPIRED,
    /// <summary>
    /// The payment request has been partially refunded.
    /// </summary>
    PARTIALREFUND,
    /// <summary>
    /// The payment request is past due.
    /// </summary>
    PASTDUE
}
