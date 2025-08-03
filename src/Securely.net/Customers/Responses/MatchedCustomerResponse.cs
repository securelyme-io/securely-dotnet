using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securely.Customers.Responses;
/// <summary>
/// Object that holds what the customer was matched on when doing an import
/// </summary>
public class MatchedCustomerResponse
{
    public CustomerResponse Customer { get; set; }

    public List<string> MatchOn { get; set; }

    public bool isExactMatch { get; set; }
}
