using System.Text.Json.Serialization;

namespace Securely.Customers.Types;

/// <summary>
/// Specifies the status of a customer in Securely.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<CustomerStatus>))]
public enum CustomerStatus {
    /// <summary>
    /// Customer is active.
    /// </summary>
    ACTIVE,
    /// <summary>
    /// Customer has been invited to use Securely.
    /// </summary>
    INVITECUSTOMER,
    /// <summary>
    /// Business customer has been invited to use Securely.
    /// </summary>
    INVITEBUSINESS,
    /// <summary>
    /// Customer has been suspended.
    /// </summary>
    SUSPENDED
}