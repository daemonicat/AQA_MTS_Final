using System.Text.Json.Serialization;

namespace QaseTestProject.Models;

public record Project
{
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("code")] public string Code { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("access")] public string Access { get; set; }
    [JsonPropertyName("counts")] public Counts Counts { get; set; }
}

public record Counts
{
    [JsonPropertyName("cases")] public int Cases { get; set; }
    [JsonPropertyName("suites")] public int Suites { get; set; }
    [JsonPropertyName("milestones")] public int Milestones { get; set; }
    [JsonPropertyName("runs")] public Runs Runs { get; set; }
    [JsonPropertyName("defects")] public Defects Defects { get; set; }
}

public record Runs
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("active")] public int Active { get; set; }
}

public record Defects
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("open")] public int Open { get; set; }
}