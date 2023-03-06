using System.ComponentModel.DataAnnotations;
using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;

namespace StackExchangeApiTags.Infrastructure.Interfaces;

/// <summary>
/// Provides methods for getting tags from StackExchange
/// </summary>
public interface IStackExchangeTagsService
{
    /// <summary>
    /// Returns collection with requested number of tags
    /// </summary>
    /// <param name="count">Number</param>
    /// <returns>Collection of tags with size of parameter count</returns>
    public Task<IEnumerable<Tag>> GetPopularTags([Range(1, uint.MaxValue)]uint count);
}