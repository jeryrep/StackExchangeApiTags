using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;

namespace StackExchangeApiTags.Infrastructure.DataTransferObjects;

public record StatisticTag(Tag Tag, string SharePercentage)
{
    public string SharePercentage { get; } = SharePercentage;
    public Tag Tag { get; } = Tag;
}