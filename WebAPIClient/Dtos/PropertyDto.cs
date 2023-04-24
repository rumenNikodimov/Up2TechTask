using System.Text.Json.Serialization;

namespace WebAPIClient.Dtos;

public class PropertyDto
{
    [JsonPropertyName("data")]
    public DataDto Data { get; set; }
    
    [JsonPropertyName("duration")]
    public string Duration { get; set; } 
    
    [JsonPropertyName("status")]
    public object? Status { get; set; }
}