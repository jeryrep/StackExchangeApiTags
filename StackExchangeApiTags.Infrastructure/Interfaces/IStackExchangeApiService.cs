using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsRequest;
using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;

namespace StackExchangeApiTags.Infrastructure.Interfaces;

/// <summary>
/// Provides methods for interacting with StackExchange API
/// </summary>
public interface IStackExchangeApiService
{
    /// <summary>
    /// Accesses StackExchange API for most popular tags in descending order.
    /// </summary>
    /// <param name="options">Object defining request options</param>
    /// <returns>Collection of tags</returns>
    public Task<IEnumerable<Tag>> GetPopularTagsFromApi(TagsOptions options);
}