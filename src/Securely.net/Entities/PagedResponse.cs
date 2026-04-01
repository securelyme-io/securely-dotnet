using Securely.Entities;

namespace Securely.net.Entities;

/// <summary>
/// A response that relies on paging
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public class PagedResponse<TResponse> : BaseResponse {
    /// <summary>
    /// Indicates that there are more results available beyond the current page.
    /// </summary>
    public bool HasMore { get ;set;}

    /// <summary>
    /// The total number of records in the search
    /// </summary>
    public long? TotalCount { get; set; }

    /// <summary>
    /// The array of items
    /// </summary>
    public List<TResponse> Payload { get; set; } = new();
}
