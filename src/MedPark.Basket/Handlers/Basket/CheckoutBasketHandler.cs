using MedPark.Basket.Domain;
using MedPark.Basket.Dto;
using MedPark.Basket.Messaging.Commands;
using MedPark.Basket.Messaging.Events;
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
    public class CheckoutBasketHandler : ICommandHandler<CheckoutBasket>
    {
        private IMedParkRepository<CustomerBasket> _basketRepo { get; }
        private IMedParkRepository<BasketItem> _basketItemRepo { get; }
        private IBusPublisher _busPublisher { get; }

        public CheckoutBasketHandler(IMedParkRepository<CustomerBasket> basketRepo, IMedParkRepository<BasketItem> basketItemRepo, IBusPublisher busPublisher)
        {
            _basketRepo = basketRepo;
            _basketItemRepo = basketItemRepo;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(CheckoutBasket command, ICorrelationContext context)
        {
            //CustomerBasket basket = await _basketRepo.GetAsync(command.BasketId);

            //if (basket is null)
            //    throw new MedParkException("basket_does_not_exist", $"A basket for customer {command.BasketId} does not exist.");

            //IEnumerable<BasketItem> items = await _basketItemRepo.FindAsync(x => x.BasketId == command.BasketId);

            // if (items.Count() == 0)
            //    throw new MedParkException("basket_items_not_valid", $"The basket {command.BasketId} items are not valid to checkout.");


            //BasketCheckedOut basketCheckedOutEvent = new BasketCheckedOut(basket.CustomerId, command.ShippingType, command.ShippingAddress);
            //List<LineItemDto> lineItems = new List<LineItemDto>();

            //items.ToList().ForEach(i =>
            //{
            //    LineItemDto lineItem = new LineItemDto { Id = Guid.NewGuid(), ProductCode = i.Code, Price = i.Price, ProductName = i.Name, Quantity = i.Quantity };
            //    lineItems.Add(lineItem);
            //});

            //basketCheckedOutEvent.Items = lineItems;

            ////Publish event to start order
            //await _busPublisher.PublishAsync(basketCheckedOutEvent, null);

            ////Empty basket
            //items.ToList().ForEach(async (i) =>
            //{
            //    await _basketItemRepo.DeleteAsync(i.Id);
            //});
        }
    }
}
