using System;
using HomeAutomation.IKEA.Response;
using HomeAutomation.Shared;
using Newtonsoft.Json;

namespace HomeAutomation.IKEA
{
    public class Devices
    {

        public void List()
        {
            string shell = "coap-client -m get -u bjarne -k K2FdNhdmGBGDb1ni coaps://192.168.1.51:5684/15001";
        }
    }
}