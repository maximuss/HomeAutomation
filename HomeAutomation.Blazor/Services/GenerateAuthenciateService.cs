using HomeAutomation.Blazor.Data.Model;
using HomeAutomation.IKEA.Request;
using Newtonsoft.Json;

namespace HomeAutomation.Blazor.Services
{
    public class GenerateAuthenciateJson
    {
        public string Get(IkeaGatewayModel gatewayModel)
        {
            //coap-client -m post -u Client_identity -k fXPzRbAS07jVbRMn e {\"9090\":\"Dev\"} coaps://192.168.1.51:5684/15011/9063
            AuthenciateJson authenciateJson = new AuthenciateJson();
            authenciateJson.UserName = gatewayModel.Username;
            string userNamePayload = JsonConvert.SerializeObject(authenciateJson);
            string coapClient =
                $"coap-client -m post -u Client_identity -k {gatewayModel.Code} e {userNamePayload} coaps://{gatewayModel.IP}:5684/15011/9063";
            return coapClient;
        }
    }
}