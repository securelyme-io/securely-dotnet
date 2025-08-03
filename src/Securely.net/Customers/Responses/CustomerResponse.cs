using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securely.Customers.Responses;
/// <summary>
/// Customer object.
/// </summary>
public class CustomerResponse
{
    /// <summary>
    /// Securely Customer ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// First name of customer.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name of customer.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Cell phone for customer.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Email for customer.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Customer Status (ACTIVE, INVITECUSTOMER, INVITEBUSINESS, SUSPENDED).
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Company name for customer. Updateable through API.
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// External identifier for customer. Expected to be a unique identifier from the API consumer's system. Updateable through API.
    /// </summary>
    public string? ExternalIdentifier { get; set; }

    /// <summary>
    /// Account number for customer.
    /// </summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Alternate Pricing Plan for customer.
    /// </summary>
    public int? AlternatePricingPlanId { get; set; }
}
