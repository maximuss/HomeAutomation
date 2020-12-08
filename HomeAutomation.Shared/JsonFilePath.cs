using Microsoft.Extensions.Configuration;
namespace HomeAutomation.Shared

{
    public class JsonFilePath
    {
        private readonly IConfiguration config;
        
        public JsonFilePath(IConfiguration config)
        {
            this.config = config;
        }

        public string IkeaGateway() => config["data-files:ikea:gateway"];
        public string IkeaDevices() => config["data-files:ikea:devices"];        
        
    }
}