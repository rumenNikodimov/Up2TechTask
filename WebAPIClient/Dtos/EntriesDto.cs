using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WebAPIClient.Dtos;

public class EntriesDto
{
    [JsonProperty(PropertyName = "feber")]
    public PropertyDto Feber { get; set; }
    
    [JsonProperty(PropertyName = "defender")]
    public PropertyDto Defender { get; set; }
    
    [JsonProperty(PropertyName = "bookerDb")]
    public PropertyDto BookerDb { get; set; }
    
    [JsonProperty(PropertyName = "profilerDb")]
    public PropertyDto ProfilerDb { get; set; }
    
    [JsonProperty(PropertyName = "hangfireDb")]
    public PropertyDto HangfireDb { get; set; }
    
    [JsonProperty(PropertyName = "cacheDb")]
    public PropertyDto CacheDb { get; set; }
    
    [JsonProperty(PropertyName = "notifierDb")]
    public PropertyDto NotifierDb { get; set; }
    
    [JsonProperty(PropertyName = "rabbitMq")]
    public PropertyDto RabbitMq { get; set; }
    
    [JsonProperty(PropertyName = "wintopAdapter-westfriesland")]
    public PropertyDto WintopAdapterWestfriesland { get; set; }
    
    [JsonProperty(PropertyName = "wintop-westfriesland")]
    public PropertyDto WintopWestfriesland { get; set; }
    
    [JsonProperty(PropertyName = "pitaneAdapter-trevvel")]
    public PropertyDto PitaneAdapterTrevvel { get; set; }
    
    [JsonProperty(PropertyName = "pitane-trevvel")]
    public PropertyDto PitaneTrevvel { get; set; }
    
    [JsonProperty(PropertyName = "wintopAdapter-trevvel")]
    public PropertyDto WintopAdapterTrevvel { get; set; }
    
    [JsonProperty(PropertyName = "wintop-trevvel")]
    public PropertyDto WintopTrevvel { get; set; }
    
    [JsonProperty(PropertyName = "wintop-zcn")]
    public PropertyDto WintopZcn { get; set; }
    
    [JsonProperty(PropertyName = "achmeaAdapter-zcn")]
    public PropertyDto AchmeaAdapterZcn { get; set; }
    
    [JsonProperty(PropertyName = "achmeaAdapter-zcnvervoer")]
    public PropertyDto AchmeaAdapterZcnvervoer { get; set; }
    
    [JsonProperty(PropertyName = "googleAdapter-trevvel")]
    public PropertyDto GoogleAdapterTrevvel { get; set; }
    
    [JsonProperty(PropertyName = "googleAdapterApi-trevvel")]
    public PropertyDto GoogleAdapterApiTrevvel { get; set; }
    
    [JsonProperty(PropertyName = "otpAdapter-trevvel")]
    public PropertyDto OtpAdapterTrevvel { get; set; }
    
    [JsonProperty(PropertyName = "otp-trevvel")]
    public PropertyDto OtpTrevvel { get; set; }
    
    [JsonProperty(PropertyName = "wintopAdapter-viave")]
    public PropertyDto WintopAdapterViave { get; set; }
    
    [JsonProperty(PropertyName = "wintop-viave")]
    public PropertyDto WintopViave { get; set; }
    
    [JsonPropertyName("fugecoAdapter")]
    public PropertyDto FugecoAdapter { get; set; }
    
    [JsonProperty(PropertyName = "fugeco")]
    public PropertyDto Fugeco { get; set; }
}