using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Securely.Customers;
using Securely.net.Options;
using Securely.net.PaymentRequests;
using Securely.Subscriptions;

namespace Securely.net.Extensions;
/// <summary>
/// Extensions to help add Securely dependencies to the service collection.
/// </summary>
public static class ServiceCollectionExtensions {
    /// <summary>
    /// Registers SecurelyService with DI and binds options from the provided configuration section.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration">The configuration root</param>
    /// <param name="sectionName">The section to bind SecurelyOptions from</param>
    public static IServiceCollection AddSecurely(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName = "Securely") // default section name
    {
        // Bind the section to SecurelyOptions
        services.Configure<SecurelyOptions>(configuration.GetSection(sectionName));

        // Register HttpClient and the service
        services.AddHttpClient();
        services.AddScoped<ISecurelyService, SecurelyService>();
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<ISubscriptionService, SubscriptionService>();
        services.AddScoped<IPaymentRequestsService, PaymentRequestsService>();

        return services;
    }
}
