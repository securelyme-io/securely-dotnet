using Microsoft.Extensions.Options;
using Securely.Entities;
using Securely.net.Entities;
using Securely.net.Options;
using Securely.net.PaymentRequests.Requests;
using Securely.net.PaymentRequests.Responses;
using Securely.Subscriptions;
using Securely.Subscriptions.Requests;
using Securely.Subscriptions.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securely.net.PaymentRequests;

/// <summary>
/// Methods to help manage payment requests in Securely.
/// </summary>
public interface IPaymentRequestsService : ISecurelyService {
    /// <summary>
    /// Retrieve a payment request from Securely based on a payment request id.
    /// </summary>
    /// <param name="paymentRequestId">The payment request id</param>
    /// <param name="apiKey">The api key from the merchant</param>
    /// <param name="apiSecret">The api secret</param>
    /// <returns></returns>
    Task<ISecurelyResponse<BaseResponse<PaymentRequestResponse>>> GetPaymentRequestAsync(string paymentRequestId, string apiKey, string apiSecret);

    /// <summary>
    /// Searches for payment requests given the supplied request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="apiKey"></param>
    /// <param name="apiSecret"></param>
    /// <returns></returns>
    Task<ISecurelyResponse<PagedResponse<PaymentRequestResponse>>> SearchPaymentRequestsAsync(SearchPaymentRequests request, string apiKey, string apiSecret);

    /// <summary>
    /// Creates a one-time payment request in Securely.
    /// </summary>
    /// <param name="request">The payment request details</param>
    /// <param name="apiKey">The API key from the merchant</param>
    /// <param name="apiSecret">The API secret</param>
    /// <returns>Response containing the new payment request ID</returns>
    Task<ISecurelyResponse<BaseResponse<CreatePaymentRequestResponse>>> CreateOneTimePaymentRequestAsync(CreateOneTimePaymentRequest request, string apiKey, string apiSecret);

    /// <summary>
    /// Creates a URL for a payment request that can be sent to the customer.
    /// </summary>
    /// <param name="paymentRequestId">The payment request ID to create a URL for</param>
    /// <param name="request">Optional URL configuration options</param>
    /// <param name="apiKey">The API key from the merchant</param>
    /// <param name="apiSecret">The API secret</param>
    /// <returns>Response containing the payment URL</returns>
    Task<ISecurelyResponse<BaseResponse<CreatePaymentUrlResponse>>> CreatePaymentUrlAsync(long paymentRequestId, CreatePaymentUrlRequest request, string apiKey, string apiSecret);
}

/// <summary>
/// Methods to help manage payment requests in Securely.
/// </summary>
public class PaymentRequestsService : SecurelyService, IPaymentRequestsService {
    /// <summary>
    /// Methods to help manage payment requests in Securely.
    /// </summary>
    public PaymentRequestsService(IOptions<SecurelyOptions> options, IHttpClientFactory httpClientFactory) : base(options, httpClientFactory) {
    }

    /// <summary>
    /// Retrieve a payment request from Securely based on a payment request id.
    /// </summary>
    /// <param name="paymentRequestId">The payment request id</param>
    /// <param name="apiKey">The api key from the merchant</param>
    /// <param name="apiSecret">The api secret</param>
    /// <returns></returns>
    public async Task<ISecurelyResponse<BaseResponse<PaymentRequestResponse>>> GetPaymentRequestAsync(string paymentRequestId, string apiKey, string apiSecret)
        => await ExecuteAsync<BaseResponse<PaymentRequestResponse>>(apiKey, apiSecret, $"/payment-requests/{paymentRequestId}");

    /// <summary>
    /// Searches for payment requests given the supplied request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="apiKey"></param>
    /// <param name="apiSecret"></param>
    /// <returns></returns>
    public async Task<ISecurelyResponse<PagedResponse<PaymentRequestResponse>>> SearchPaymentRequestsAsync(SearchPaymentRequests request, string apiKey, string apiSecret)
        => await ExecuteAsync<SearchPaymentRequests, PagedResponse<PaymentRequestResponse>>(request, apiKey, apiSecret, "/payment-requests/search");

    /// <summary>
    /// Creates a one-time payment request in Securely.
    /// </summary>
    /// <param name="request">The payment request details</param>
    /// <param name="apiKey">The API key from the merchant</param>
    /// <param name="apiSecret">The API secret</param>
    /// <returns>Response containing the new payment request ID</returns>
    public async Task<ISecurelyResponse<BaseResponse<CreatePaymentRequestResponse>>> CreateOneTimePaymentRequestAsync(CreateOneTimePaymentRequest request, string apiKey, string apiSecret)
        => await ExecuteAsync<CreateOneTimePaymentRequest, BaseResponse<CreatePaymentRequestResponse>>(request, apiKey, apiSecret, "/payment-requests/one-time");

    /// <summary>
    /// Creates a URL for a payment request that can be sent to the customer.
    /// </summary>
    /// <param name="paymentRequestId">The payment request ID to create a URL for</param>
    /// <param name="request">Optional URL configuration options</param>
    /// <param name="apiKey">The API key from the merchant</param>
    /// <param name="apiSecret">The API secret</param>
    /// <returns>Response containing the payment URL</returns>
    public async Task<ISecurelyResponse<BaseResponse<CreatePaymentUrlResponse>>> CreatePaymentUrlAsync(long paymentRequestId, CreatePaymentUrlRequest request, string apiKey, string apiSecret)
        => await ExecuteAsync<CreatePaymentUrlRequest, BaseResponse<CreatePaymentUrlResponse>>(request, apiKey, apiSecret, $"/payment-requests/{paymentRequestId}/urls");
}
