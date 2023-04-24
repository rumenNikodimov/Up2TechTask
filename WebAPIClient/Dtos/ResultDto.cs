using System.Text.Json.Serialization;

namespace WebAPIClient.Dtos;

public class ResultDto
{
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    [JsonPropertyName("totalDuration")]
    public string TotalDuration { get; set; }
    
    [JsonPropertyName("entries")]
    public EntriesDto Entries { get; set; }
}