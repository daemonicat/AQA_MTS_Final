using System.Text.Json.Serialization;

namespace QaseTestProject.Models.API;

public record TestCase
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;
    [JsonPropertyName("severity")] public int Severity { get; set; }
    [JsonPropertyName("priority")] public int Priority { get; set; }
    [JsonPropertyName("type")] public int Type { get; set; }
    [JsonPropertyName("layer")] public int Layer { get; set; }
    [JsonPropertyName("behavior")] public int Behavior { get; set; }
    [JsonPropertyName("automation")] public int Automation { get; set; }
    [JsonPropertyName("author_id")] public int AuthorId { get; set; }
    [JsonPropertyName("created_at")] public string CreatedAt { get; set; } = string.Empty;
    [JsonPropertyName("updated_at")] public string UpdatedAt { get; set; } = string.Empty;
}