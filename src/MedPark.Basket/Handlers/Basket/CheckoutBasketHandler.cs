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
        private IMedParkRepository<Product> _productRepo { get; }

        private IBusPublisher _busPublisher { get; }

        public CheckoutBasketHandler(IMedParkRepository<CustomerBasket> basketRepo, IMedParkRepository<BasketItem> basketItemRepo, IBusPublisher busPublisher, IMedParkRepository<Product> productRepo)
        {
            _basketRepo = basketRepo;
            _basketItemRepo = basketItemRepo;
            _busPublisher = busPublisher;
            _productRepo = productRepo;
        }

        public async Task HandleAsync(CheckoutBasket command, ICorrelationContext context)
        {
            CustomerBasket basket = await _basketRepo.GetAsync(command.BasketId);

            if (basket is null)
                throw new MedParkException("basket_does_not_exist", $"A basket for customer {command.BasketId} does not exist.");

            IEnumerable<BasketItem> items = await _basketItemRepo.FindAsync(x => x.BasketId == command.BasketId);


            BasketCheckedOut basketCheckedOutEvent = new BasketCheckedOut(basket.CustomerId, command.ShippingType, command.ShippingAddress);
            List<LineItemDto> lineItems = new List<LineItemDto>();

            items.ToList().ForEach(async (i) =>
            {
                Product p = await _productRepo.GetAsync(i.ProductId);

                LineItemDto lineItem = new LineItemDto { Id = Guid.NewGuid(), ProductCode = p.Code, Price = p.Price, ProductName = p.Name, Quantity = i.Quantity };
                lineItems.Add(lineItem);
            });

            basketCheckedOutEvent.Items = lineItems;

            //Publish event to start order
            await _busPublisher.PublishAsync(basketCheckedOutEvent, null);

            //Empty basket
            //await _basketItemRepo.DeleteAllAsync(x => x.BasketId == command.BasketId);


            //TODO: Update Cache with empty basket
        }
    }
}
