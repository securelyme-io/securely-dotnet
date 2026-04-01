using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securely.net.PaymentRequests.Enum;

/// <summary>
/// Current status of transaction
/// </summary>
public enum TransactionStatus {
    /// <summary>
    /// Transaction is captured but not paid out
    /// </summary>
    AUTHORIZED,
    /// <summary>
    /// Transaction has been paid to bank account
    /// </summary>
    SETTLED,
    /// <summary>
    /// The transaction was ignored and was not successful
    /// </summary>
    IGNORED,
    /// <summary>
    /// Is inititated or pending, waiting on gateway for final state
    /// </summary>
    INITIATED,
    /// <summary>
    /// The transaction failed
    /// </summary>
    FAILED,
    /// <summary>
    /// This is for DIGITAL CASH
    /// </summary>
    PENDING
}
