using MedPark.Basket.Messaging.Commands;
using MedPark.Basket.Messaging.Events;
using MedPark.Common.Dispatchers;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Handlers.Customers
{
    public class CustomerCreatedHandler : IEventHandler<CustomerCreated>
    {
        private IDispatcher _dispatcher {get;}

        public CustomerCreatedHandler(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public async Task HandleAsync(CustomerCreated @event, ICorrelationContext context)
        {
            CreateBasket newBasket = new CreateBasket(Guid.NewGuid(), @event.UserId);

            await _dispatcher.SendAsync(newBasket);
        }
    }
}
