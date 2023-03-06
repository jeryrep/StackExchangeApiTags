using System.ComponentModel.DataAnnotations;

namespace StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsRequest;

public record TagsOptions
{
    [Range(1, int.MaxValue)] public int Page { get; set; } = 1;
    [Range(1, 100)] public byte PageSize { get; set; } = 30;
    [Range(0, int.MaxValue)] public int FromDate { get; set; } = 0;
    [Range(0, int.MaxValue)] public int ToDate { get; set; } = int.MaxValue;
    public string Order { get; set; } = TagsOrder.Descending;
    public int Min { get; set; } = 0;
    public int Max { get; set; } = int.MaxValue;
    public string Sort { get; set; } = TagsSort.Popular;
#nullable enable
    public string? InName { get; set; } = string.Empty;
}