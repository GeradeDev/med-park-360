using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.OrderService.Domain;
using MedPark.OrderService.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Handlers.Basket
{
    public class BasketCheckedOutHandler : IEventHandler<BasketCheckedOut>
    {
        private IMedParkRepository<Order> _orderRepo { get; }
        private IMedParkRepository<LineItem> _lineItemsRepo { get; }
        private IBusPublisher _busPublisher {get;}

        public BasketCheckedOutHandler(IMedParkRepository<Order> orderRepo, IMedParkRepository<LineItem> lineItemsRepo, IBusPublisher busPublisher)
        {
            _orderRepo = orderRepo;
            _lineItemsRepo = lineItemsRepo;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(BasketCheckedOut @event, ICorrelationContext context)
        {
            //Create new Order
            Order newOrder = new Order(Guid.NewGuid());
            var orderCount = await _orderRepo.GetAllAsync();
            var newOrderNo = String.Empty.GenerateOrderNo((orderCount.ToList().Count() + 1));

            newOrder.CreateNewOrder(@event.CustomerId, newOrderNo, (int)MedParkEnums.OrderStatus.Placed);
            newOrder.SetOrderTotal(@event.Items.ToList().Sum(x => x.Price));
            newOrder.SetShipping(@event.ShippingType, @event.ShippingAddress);

            await _orderRepo.AddAsync(newOrder);


            //Create new order line items
            List<LineItem> orderItems = new List<LineItem>();
            @event.Items.ToList().ForEach(async (item) =>
            {
                LineItem orderItem = new LineItem(item.Id);

                orderItem.CreateOrderLineItem(newOrder.Id, item.ProductCode, item.ProductName, item.ProductDescription, item.NappiCode, item.Price);
                orderItem.SetQuantity(item.Quantity);

                orderItems.Add(orderItem);

                await _lineItemsRepo.AddAsync(orderItem);
            });

            //Publish Order Placed event
            await _busPublisher.PublishAsync(new OrderPlaced(newOrder.Id, newOrder.CustomerId, newOrder.OrderTotal), null);
        }
    }
}
