using System;
using System.Diagnostics;
using HomeAutomation.IKEA.Request;
using HomeAutomation.IKEA.Response;
using HomeAutomation.Shared;
using Newtonsoft.Json;

namespace HomeAutomation.IKEA
{
    public class Gateway
    {
        public PresharedKeyJson Authenciate(string gatewayCode, string gatewayIp, string username)
        {
            //coap-client -m post -u "Client_identity" -k "$TF_GATEWAYCODE" -e "{\"9090\":\"$TF_USERNAME\"}" "coaps://$TF_GATEWAYIP:5684/15011/9063"
            AuthenciateJson authenciateJson = new AuthenciateJson();
            authenciateJson.UserName = username;
            string usernameJson = JsonConvert.SerializeObject(authenciateJson);
            string shell =
                $"coap-client -m post -u \"Client_identity\" -k \"{gatewayCode}\" -e {usernameJson}"+$" coaps://{gatewayIp}:5684/15011/9063";
            Debug.WriteLine(shell);
            try
            {
                ShellHelper shellHelper = new ShellHelper();
                shellHelper.Bash(shell);
                PresharedKeyJson presharedKeyJson = JsonConvert.DeserializeObject<PresharedKeyJson>(shellHelper.Result);
                return presharedKeyJson;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}