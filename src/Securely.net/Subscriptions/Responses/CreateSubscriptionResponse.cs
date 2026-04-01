namespace Securely.Subscriptions.Responses;

/// <summary>
/// When creating a subscription, this response is returned.
/// </summary>
public class CreateSubscriptionResponse {
    /// <summary>
    /// The ID to represent the subscription that was created.
    /// </summary>
    public int SubscriptionId { get; set; }
}
