using AutoMapper;
using SwiftBookingTest.Model;
using SwiftBookingTest.Model.Client;
using System.Collections.Generic;
using System;
using SwiftBookingTest.CoreContracts.Tasks;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class AutoMapperConfig : IRunAtInit
    {

        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ClientPhone, ClientPhoneViewModel>();
                cfg.CreateMap<ClientRecord, ClientRecordViewModel>();
            });

            Mapper.Map<ClientPhone, ClientPhoneViewModel>(new ClientPhone());
            Mapper.Map<ClientRecord, ClientRecordViewModel>(new ClientRecord());
        }

        public void Execute()
        {
            RegisterMappings();
        }
    }

}