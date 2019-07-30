using MedPark.Basket.Domain;
using MedPark.Basket.Messaging.Commands;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Handlers.Basket
{
    public class AddProductToBasketHandler : ICommandHandler<AddProductToBasket>
    {
        private IMedParkRepository<CustomerBasket> _basketRepo { get; }
        private IMedParkRepository<BasketItem> _itemRepo { get; }

        public AddProductToBasketHandler(IMedParkRepository<CustomerBasket> basketRepo, IMedParkRepository<BasketItem> itemRepo)
        {
            _basketRepo = basketRepo;
            _itemRepo = itemRepo;
        }

        public async Task HandleAsync(AddProductToBasket command, ICorrelationContext context)
        {
            CustomerBasket basket = await _basketRepo.GetAsync(command.BasketId);

            if (basket is null)
                throw new MedParkException("basket_does_not_exist", $"The basket {command.BasketId} does not exist.");

            BasketItem bItem = await _itemRepo.GetAsync(x => x.BasketId == basket.Id && x.ProductId == command.Item.ProductId);

            if(bItem != null)
                throw new MedParkException("basket_already_exists", $"The product {command.Item.ProductId} has already been added to the basket.");

            await _itemRepo.AddAsync(command.Item);
        }
    }
}
