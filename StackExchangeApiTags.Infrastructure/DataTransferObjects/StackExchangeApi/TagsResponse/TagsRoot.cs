using System.Text.Json.Serialization;

namespace StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;

public record TagsRoot
{
    public List<Tag> Items { get; set; } = new();
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }
    [JsonPropertyName("quota_max")] public int QuotaMax { get; set; }
    [JsonPropertyName("quota_remaining")] public int QuotaRemaining { get; set; }
}