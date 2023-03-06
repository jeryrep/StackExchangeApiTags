using System.Text.Json.Serialization;

namespace StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;

public record Collective
{
    public List<string> Tags { get; set; } = new();
    [JsonPropertyName("external_links")] public List<ExternalLink> ExternalLinks { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
}