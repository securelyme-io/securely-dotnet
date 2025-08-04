using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Securely.Customers.Requests;
using Securely.Customers.Responses;


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
    Task<ImportCustomerResponse> ImportCustomerAsync(ImportCustomerRequest request);
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
    public async Task<ImportCustomerResponse> ImportCustomerAsync(ImportCustomerRequest request)
    {
        // Implementation of the import logic goes here.
        // This is a placeholder implementation.
        return await Task.FromResult(new ImportCustomerResponse
        {
            Customers = new List<MatchedCustomerResponse>()
        });
    }
}