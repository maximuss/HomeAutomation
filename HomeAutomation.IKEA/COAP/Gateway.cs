using HomeAutomation.Shared;

namespace HomeAutomation.IKEA
{
    public class Gateway
    {
        private readonly JsonFilePath jsonFilePath;

        public Gateway(JsonFilePath jsonFilePath)
        {
            this.jsonFilePath = jsonFilePath;
        }
        
        public void Authenciate(string gatewayCode, string gatewayIp, string username)
        {
            // //coap-client -m post -u "Client_identity" -k "$TF_GATEWAYCODE" -e "{\"9090\":\"$TF_USERNAME\"}" "coaps://$TF_GATEWAYIP:5684/15011/9063"
            // AuthenciateJson authenciateJson = new AuthenciateJson();
            // authenciateJson.UserName = username;
            // string usernameJson = JsonConvert.SerializeObject(authenciateJson);
            // usernameJson = usernameJson.Replace("\"", "\\\"");
            // //string shell = $" -m post -u Client_identity -o {jsonFilePath.IkeaGateway()}  -k {gatewayCode} -e {usernameJson} coaps://{gatewayIp}:5684/15011/9063";
            // string shell =
            //     " -m get -u DevConsol2 -k h7BBDR9hsSWhEhIZ -o /home/bjarne/.homeautomation/gateway/ikea/gateway.json  coaps://192.168.1.51:5684/15011/15012";
            // // string shell =
            // //     $" -m get -u bjarne -o {jsonFilePath.IkeaDevices()} -B 3 -k K2FdNhdmGBGDb1ni coaps://192.168.1.51:5684/15001";
            // ShellHelper shellHelper = new ShellHelper();
            // shellHelper.Bash(shell);
        }
    }
}