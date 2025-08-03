using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Securely.Customers;
public interface ICustomersService
{
    /// <summary>
    /// Imports customers into Securely.
    /// </summary>
    /// <param name="request">The request containing the customers to import.</param>
    /// <returns>A response containing the results of the import.</returns>
    Task<Responses.ImportCustomerResponse> ImportCustomersAsync(Requests.ImportCustomerRequest request);
}
public class CustomersService
{
}
