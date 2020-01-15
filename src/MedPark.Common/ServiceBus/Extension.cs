using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedPark.Common.ServiceBus
{
    public static class Extension
    {
        public static void AddServiceBus(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<AzureServiceBusConfig>("azureBus");

                return options;
            }).SingleInstance();


        }
    }
}
