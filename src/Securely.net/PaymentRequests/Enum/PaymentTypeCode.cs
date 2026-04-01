using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securely.net.PaymentRequests.Enum;

/// <summary>
/// The type of payment 
/// </summary>
public enum PaymentTypeCode {
    /// <summary>
    /// A one-time payment.
    /// </summary>
    ONETIME,
    /// <summary>
    /// A recurring payment (e.g., subscription).
    /// </summary>
    RECURRING,
    /// <summary>
    /// A payment made at a terminal or point of sale.
    /// </summary>
    TERMINAL,
    /// <summary>
    /// A quick pay transaction.
    /// </summary>
    QUICKPAY,
    /// <summary>
    /// A refund transaction.
    /// </summary>
    REFUND
}
