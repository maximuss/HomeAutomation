using System;
using System.IO;
using AutoMapper;
using AutoMapper.Configuration;
using HomeAutomation.Database.Entity;
using HomeAutomation.Database.Repository;
using HomeAutomation.IKEA.Model;
using HomeAutomation.IKEA.Response;
using HomeAutomation.Shared;
using Newtonsoft.Json;

namespace HomeAutomation.IKEA.Services
{
    public class IkeaGatewayService
    {
        private readonly GatewayRepository gatewayRepository;
        private readonly Gateway gateway;
        private readonly JsonFilePath jsonFilePath;
        
        public IkeaGatewayService(Gateway gateway, GatewayRepository gatewayRepository, JsonFilePath jsonFilePath)
        {
            this.gateway = gateway;
            this.gatewayRepository = gatewayRepository;
            this.jsonFilePath = jsonFilePath;
        }
        public PresharedKeyModel SaveIkeaGatewayInfo(string name, string ip, string code, string displayName)
        {
            gateway.Authenciate(code, ip, name);
            PresharedKeyModel keyModel = new PresharedKeyModel();
            //Check if the gateway file exist
            if(File.Exists(jsonFilePath.IkeaGateway()))
            {
                keyModel = JsonConvert.DeserializeObject<PresharedKeyModel>(jsonFilePath.IkeaGateway());
                if (keyModel == null)
                {
                    keyModel = new PresharedKeyModel();
                    keyModel.ErrorMessage = "Ingen preshared key oprettet - check dine data og prøv igen";
                }
                else
                {
                    SaveIkeaGatewaySettings(name,ip,code,displayName,keyModel.PresharedKey,keyModel.GatewayVersion);
                    File.Delete(jsonFilePath.IkeaGateway());
                }
                return keyModel;
            }
            else
            {
                keyModel.ErrorMessage =
                    $"{jsonFilePath.IkeaGateway()} eksistere ikke - opret den og prøv igen";
            }

            return null;
        }

        private void SaveIkeaGatewaySettings(string name, string ip, string code, string displayName, string presharedKey, string gatewayVersion)
        {
            GatewayEntity gatewayEntity = new GatewayEntity();
            gatewayEntity.Supplier = Supplier.IKEA.ToString();
            gatewayEntity.Code = code;
            gatewayEntity.Username = name;
            gatewayEntity.IP = ip;
            gatewayEntity.DisplayName = displayName;
            gatewayEntity.PresharedKey = presharedKey;
            gatewayEntity.GatewayVersion = gatewayVersion;
            gatewayRepository.SaveOrUpdate(gatewayEntity);
        }
    }
}