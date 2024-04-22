using System.Text.Json.Serialization;

namespace QaseTestProject.Models;

public record Project
{
    [JsonPropertyName("status")] public string Status { get; set; } = string.Empty;
    [JsonPropertyName("result")] public Result Result { get; set; }

}

public record Result
{
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("code")] public string Code { get; set; } = string.Empty;
    [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;
    [JsonPropertyName("access")] public string Access { get; set; } = string.Empty;
    [JsonPropertyName("counts")] public Counts Counts { get; set; }
}

public record Counts
{
    [JsonPropertyName("cases")] public string Cases { get; set; } = string.Empty;
    [JsonPropertyName("suites")] public string Suites { get; set; } = string.Empty;
    [JsonPropertyName("milestones")] public string Milestones { get; set; } = string.Empty;
    [JsonPropertyName("runs")] public Runs Runs { get; set; }
    [JsonPropertyName("defects")] public Defects Defects { get; set; }
}

public record Runs
{
    [JsonPropertyName("total")] public string Total { get; set; } = string.Empty;
    [JsonPropertyName("active")] public string Active { get; set; } = string.Empty;
}

public record Defects
{
    [JsonPropertyName("total")] public string Total { get; set; } = string.Empty;
    [JsonPropertyName("open")] public string Open { get; set; } = string.Empty;
}