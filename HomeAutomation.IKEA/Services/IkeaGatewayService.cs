using System;
using AutoMapper;
using HomeAutomation.Database.Entity;
using HomeAutomation.Database.Repository;
using HomeAutomation.IKEA.Model;
using HomeAutomation.IKEA.Response;
using HomeAutomation.Shared;

namespace HomeAutomation.IKEA.Services
{
    public class IkeaGatewayService
    {
        private readonly IMapper mapper;
        private readonly GatewayRepository gatewayRepository;

        public IkeaGatewayService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public PresharedKeyModel SavePreSharedKey(string name, string ip, string code)
        {
            Gateway gateway = new Gateway();
            PresharedKeyJson presharedKeyJson = gateway.Authenciate(code, ip, name);
            if (presharedKeyJson != null)
            {
                PresharedKeyModel presharedKeyModel = mapper.Map<PresharedKeyModel>(presharedKeyJson);
                GatewayEntity gatewayEntity = new GatewayEntity();
                gatewayEntity.Supplier = Supplier.IKEA.ToString();
                gatewayEntity.Code = presharedKeyJson.PresharedKey;
                gatewayEntity.Username = name;
                gatewayEntity.GatewayVersion = presharedKeyJson.GatewayVersion;
                gatewayEntity.IP = ip;
                gatewayRepository.SaveOrUpdate(gatewayEntity);
                return presharedKeyModel;
            }

            return null;
        }
    }
}