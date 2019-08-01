using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Payment.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Handlers.OrderService
{
    public class OrderPlacedHandler : IEventHandler<OrderPlaced>
    {
        public Task HandleAsync(OrderPlaced @event, ICorrelationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
