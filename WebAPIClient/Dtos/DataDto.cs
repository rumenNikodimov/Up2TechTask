using System.Text.Json.Serialization;

namespace WebAPIClient.Dtos;

public class DataDto
{
    public string? Version { get; set; }
    
    public string? VersionInfo { get; set; }
    
    public string? EnvironmentName { get; set; }
    
    public string? Culture { get; set; }
    
    public DateTime? UtcTime { get; set; }
    
    [JsonPropertyName("cached")]
    public string? Cached { get; set; }
}