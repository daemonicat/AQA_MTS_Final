using System.Text.Json.Serialization;

namespace QaseTestProject.Models;

public record TestCase
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("position")] public int Position { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    //[JsonPropertyName("preconditions")] public string Preconditions { get; set; }
    //[JsonPropertyName("postconditions")] public string Postconditions { get; set; }
    [JsonPropertyName("severity")] public int Severity { get; set; }
    [JsonPropertyName("priority")] public int Priority { get; set; }
    [JsonPropertyName("type")] public int Type { get; set; }
    [JsonPropertyName("layer")] public int Layer { get; set; }
    [JsonPropertyName("behavior")] public int Behavior { get; set; }
    [JsonPropertyName("automation")] public int Automation { get; set; }
    [JsonPropertyName("status")] public int Status { get; set; }
    [JsonPropertyName("suite_id")] public int SuiteId { get; set; }
    [JsonPropertyName("author_id")] public int AuthorId { get; set; }
    [JsonPropertyName("created_at")] public string CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public string UpdatedAt { get; set; }
}