namespace Securely.Customers.Responses;
/// <summary>
/// Object that holds what the customer was matched on when doing an import
/// </summary>
public class MatchedCustomerResponse {
    /// <summary>
    /// Customer object.
    /// </summary>
    public CustomerResponse? Customer { get; set; }

    /// <summary>
    /// List of matching fields for customer based on request.
    /// </summary>
    public List<string> MatchOn { get; set; } = new();

    /// <summary>
    /// Whether or not the customer matches the import request exactly.
    /// </summary>
    public bool isExactMatch { get; set; } = false;
}
