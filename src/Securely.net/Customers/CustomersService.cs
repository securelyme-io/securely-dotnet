using Microsoft.Extensions.Options;
using Securely.Customers.Requests;
using Securely.Customers.Responses;
using Securely.Entities;
using Securely.net.Options;


namespace Securely.Customers;

/// <summary>
/// Methods to help manage customers in Securely.
/// </summary>
public interface ICustomersService : ISecurelyService {
    /// <summary>
    /// Imports customers into Securely.
    /// </summary>
    /// <param name="request">The request containing the customers to import.</param>
    /// <param name="apiKey">The api key from the merchant</param>
    /// <param name="apiSecret">The api secret</param>
    /// <returns>A response containing the results of the import.</returns>
    Task<ISecurelyResponse<BaseResponse<ImportCustomerResponse>>> ImportCustomerAsync(ImportCustomerRequest request, string apiKey, string apiSecret);
}

/// <summary>
/// Methods to help manage customers in Securely.
/// </summary>
public class CustomersService : SecurelyService, ICustomersService {
    /// <summary>
    /// Methods to help manage customers in Securely.
    /// </summary>
    public CustomersService(IOptions<SecurelyOptions> options, IHttpClientFactory httpClientFactory) : base(options, httpClientFactory) {
    }

    /// <summary>
    /// Imports a customer into Securely or finds an existing customer based on the provided request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="apiKey">The api key from the merchant</param>
    /// <param name="apiSecret">The api secret</param>
    /// <returns></returns>
    public async Task<ISecurelyResponse<BaseResponse<ImportCustomerResponse>>> ImportCustomerAsync(ImportCustomerRequest request, string apiKey, string apiSecret)
        => await ExecuteAsync<ImportCustomerRequest, BaseResponse<ImportCustomerResponse>>(request, apiKey, apiSecret, "/customers/import");
}