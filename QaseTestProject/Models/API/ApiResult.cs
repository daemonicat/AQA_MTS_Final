using System.Text.Json.Serialization;

namespace QaseTestProject.Models.API;

public abstract class ApiResult<T>
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public T Result { get; set; }
    [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; } = string.Empty;
}