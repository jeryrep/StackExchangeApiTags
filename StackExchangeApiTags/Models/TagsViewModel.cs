using StackExchangeApiTags.Infrastructure.DataTransferObjects;

namespace StackExchangeApiTags.Models;

public class TagsViewModel
{
    public IEnumerable<StatisticTag> StatisticTags { get; }

    public TagsViewModel(IEnumerable<StatisticTag> statisticTags) => StatisticTags = statisticTags;
}