using StackExchangeApiTags.Infrastructure.DataTransferObjects;
using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;
using StackExchangeApiTags.Infrastructure.Interfaces;

namespace StackExchangeApiTags.Infrastructure.Services;

public class CalculationService : ICalculationService
{
    public IEnumerable<StatisticTag> GetTagsWithCalculatedShare(List<Tag> tags)
    {
        var sum = tags.Sum(x => x.Count);
        return tags.Select(tag => new StatisticTag(tag, $"{tag.Count / (float)sum * 100}%"));
    }
}