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
    public class UpdateBasketHandler : ICommandHandler<UpdateBasket>
    {
        private IMedParkRepository<CustomerBasket> _basketRepo { get; }
        private IMedParkRepository<BasketItem> _basketItemRepo { get; }

        public UpdateBasketHandler(IMedParkRepository<CustomerBasket> basketRepo, IMedParkRepository<BasketItem> basketItemRepo)
        {
            _basketRepo = basketRepo;
            _basketItemRepo = basketItemRepo;
        }

        public async Task HandleAsync(UpdateBasket command, ICorrelationContext context)
        {
            CustomerBasket basket = await _basketRepo.GetAsync(command.BasketId);

            if (basket is null)
                throw new MedParkException("basket_does_not_exist", $"The basket {command.BasketId} does not exist.");

            command.Items.ToList().ForEach(async (item) =>
            {
                BasketItem bItem = await _basketItemRepo.GetAsync(x => x.BasketId == basket.Id && x.ProductId == item.ProductId);

                bItem.UpdateQuatity(item.Quantity);
                bItem.UpdatedModifiedDate();

                await _basketItemRepo.UpdateAsync(bItem);
            });
        }
    }
}
