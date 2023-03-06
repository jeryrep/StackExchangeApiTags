using System.Text.Json.Serialization;

namespace StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;

public record Tag
{
    public string Name { get; set; } = string.Empty;
    public uint Count { get; set; }
    [JsonPropertyName("has_synonyms")] public bool HasSynonyms { get; set; }

    [JsonPropertyName("is_moderator_only")] public bool IsModeratorOnly { get; set; }

    [JsonPropertyName("is_required")] public bool IsRequired { get; set; }
    public List<Collective> Collectives { get; set; } = new();
}