using MedPark.Basket.Domain;
using MedPark.Basket.Messaging.Commands;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Handlers.Basket
{
    public class CreateBasketHandler : ICommandHandler<CreateBasket>
    {
        private IMedParkRepository<CustomerBasket> _basketRepo { get; }

        public CreateBasketHandler(IMedParkRepository<CustomerBasket> basketRepo)
        {
            _basketRepo = basketRepo;
        }

        public async Task HandleAsync(CreateBasket command, ICorrelationContext context)
        {
            CustomerBasket newBasket = new CustomerBasket(command.BasketId);
            newBasket.CreateBasket(command.BuyerId);

            await _basketRepo.AddAsync(newBasket);
        }
    }
}
