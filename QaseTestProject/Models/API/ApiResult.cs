using System.Text.Json.Serialization;

namespace QaseTestProject.Models;

public class ApiResult<T>
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public T Result { get; set; }
    [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; }
}