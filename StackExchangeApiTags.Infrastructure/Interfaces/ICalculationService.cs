using StackExchangeApiTags.Infrastructure.DataTransferObjects;
using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;

namespace StackExchangeApiTags.Infrastructure.Interfaces;

/// <summary>
/// Provides method for calculating that are used in the app
/// </summary>
public interface ICalculationService
{
    /// <summary>
    /// Calculates and returns new collection of tags with share percentage.
    /// </summary>
    /// <param name="tags">List with tags that will be used to calculate percentage.</param>
    /// <returns>Collection with information about share percentage and provided tags.</returns>
    public IEnumerable<StatisticTag> GetTagsWithCalculatedShare(List<Tag> tags);
}