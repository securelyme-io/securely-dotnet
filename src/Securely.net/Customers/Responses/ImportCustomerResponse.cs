using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securely.Customers.Responses;
/// <summary>
/// The response for doing a customer import
/// </summary>
public class ImportCustomerResponse
{
    /// <summary>
    /// The customers that were matched or created during the import
    /// </summary>
    public List<MatchedCustomerResponse> Customers { get; set; } = new();
}
