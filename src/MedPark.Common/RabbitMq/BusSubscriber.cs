using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedPark.Common.RabbitMq
{
    public class BusSubscriber : IBusSubscriber
    {

        public BusSubscriber(IApplicationBuilder app)
        {

        }
    }
}
