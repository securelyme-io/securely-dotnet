namespace Securely.Customers.Requests;
/// <summary>
/// 
/// </summary>
public class ImportCustomerRequest
{
    /// <summary>
    /// First name of customer, used when creating a new customer.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Last name of customer, used when creating a new customer.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Email for customer. Used for matching on existing customers. Request must include an email and/or a phone.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Cell phone for customer. Used for matching on existing customers. Request must include an email and/or a phone.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// External identifier for customer. Expected to be a unique identifier from the API consumer's system.
    /// Matching on external identifier takes precendence over email and phone matches
    /// </summary>
    public string? ExternalIdentifier { get; set; }
}
