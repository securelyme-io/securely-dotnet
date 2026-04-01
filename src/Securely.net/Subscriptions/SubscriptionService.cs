using Microsoft.Extensions.Options;
using Securely.Entities;
using Securely.net.Options;
using Securely.Subscriptions.Requests;
using Securely.Subscriptions.Responses;

namespace Securely.Subscriptions;

/// <summary>
/// Methods to help manage a subscription in Securely
/// </summary>
public interface ISubscriptionService : ISecurelyService {
    /// <summary>
    /// Creates a new subscription asynchronously based on the specified request.
    /// </summary>
    /// <remarks>Ensure that the <paramref name="request"/> object is properly populated with  all required
    /// fields before calling this method. This method performs validation  on the request and may throw exceptions if
    /// the input is invalid.</remarks>
    /// <param name="request">The request object containing the details of the subscription to be created.  This must include all required
    /// fields for the subscription.</param>
    /// <param name="apiKey">The api key from the merchant</param>
    /// <param name="apiSecret">The api secret</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains  a <see
    /// cref="CreateSubscriptionResponse"/> object with details of the created subscription.</returns>
    Task<ISecurelyResponse<BaseResponse<CreateSubscriptionResponse>>> CreateSubscriptionAsync(CreateSubscriptionRequest request, string apiKey, string apiSecret);
}

/// <summary>
/// Methods to help manage customers in Securely.
/// </summary>
public class SubscriptionService : SecurelyService, ISubscriptionService {
    /// <summary>
    /// Methods to help manage customers in Securely.
    /// </summary>
    public SubscriptionService(IOptions<SecurelyOptions> options, IHttpClientFactory httpClientFactory) : base(options, httpClientFactory) {
    }

    /// <summary>
    /// Imports a customer into Securely or finds an existing customer based on the provided request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="apiKey">The api key from the merchant</param>
    /// <param name="apiSecret">The api secret</param>
    /// <returns></returns>
    public async Task<ISecurelyResponse<BaseResponse<CreateSubscriptionResponse>>> CreateSubscriptionAsync(CreateSubscriptionRequest request, string apiKey, string apiSecret)
        => await ExecuteAsync<CreateSubscriptionRequest, BaseResponse<CreateSubscriptionResponse>>(request, apiKey, apiSecret, "/subscriptions/create");
}
