using Securely.Customers.Requests;
using Securely.Customers.Responses;
using Securely.Entities;


namespace Securely.Customers;

/// <summary>
/// Methods to help manage customers in Securely.
/// </summary>
public interface ICustomersService
{
    /// <summary>
    /// Imports customers into Securely.
    /// </summary>
    /// <param name="request">The request containing the customers to import.</param>
    /// <returns>A response containing the results of the import.</returns>
    Task<ISecurelyResponse<ImportCustomerResponse?>> ImportCustomerAsync(ImportCustomerRequest request);
}

/// <summary>
/// Methods to help manage customers in Securely.
/// </summary>
public class CustomersService : SecurelyService, ICustomersService
{
    /// <summary>
    /// Methods to help manage customers in Securely.
    /// </summary>
    public CustomersService(string apiKey, string apiSecret, bool isSandbox) : base(apiKey, apiSecret, isSandbox)
    {
    }

    /// <summary>
    /// Imports a customer into Securely or finds an existing customer based on the provided request.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<ISecurelyResponse<ImportCustomerResponse?>> ImportCustomerAsync(ImportCustomerRequest request)
        => await ExecuteAsync<ImportCustomerRequest, ImportCustomerResponse>(request, "/customers/import");
}