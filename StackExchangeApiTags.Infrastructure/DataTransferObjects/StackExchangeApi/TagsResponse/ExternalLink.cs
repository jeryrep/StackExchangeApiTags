namespace StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;

public record ExternalLink
{
    public string Type { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}