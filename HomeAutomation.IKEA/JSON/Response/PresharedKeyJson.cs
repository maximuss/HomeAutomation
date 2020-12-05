using Newtonsoft.Json;

namespace HomeAutomation.IKEA.Response
{
    public class PresharedKeyJson
    {
            [JsonProperty("9091")]
            public string PresharedKey { get; set; } 

            [JsonProperty("9029")]
            public string GatewayVersion { get; set; } 

    }
}