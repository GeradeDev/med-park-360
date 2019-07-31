using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.OrderService.Domain;
using MedPark.OrderService.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Handlers.OrderService
{
    public class UpdateOrderItemQuantityHandler : ICommandHandler<UpdateOrderItemQuantity>
    {
        private IMedParkRepository<Order> _orderRepo { get; }
        private IMedParkRepository<LineItem> _orderItemRepo { get; }

        public UpdateOrderItemQuantityHandler(IMedParkRepository<Order> orderRepo, IMedParkRepository<LineItem> orderItemRepo)
        {
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
        }

        public async Task HandleAsync(UpdateOrderItemQuantity command, ICorrelationContext context)
        {
            Order o = await _orderRepo.GetAsync(command.OrderId);

            if (o is null)
                throw new MedParkException("update_item_order_does_not_exist", $"Order {command.OrderId} does not exist.");

            var prodExists = await _orderItemRepo.GetAsync(x => x.OrderId == command.OrderId && x.ProductCode == command.ProductCode);
            if (prodExists != null)
            {
                //RUpdate the line quantity
                prodExists.SetQuantity(command.Quantity);

                //Update the order total after item was removed
                decimal newTotal = o.LineItems.Sum(x => x.Price);
                o.SetOrderTotal(newTotal);


                //Update Order
                await _orderItemRepo.UpdateAsync(prodExists);
                await _orderRepo.UpdateAsync(o);
            }
            else
            {
                throw new MedParkException("order_item_does_not_exist", $"Order {command.OrderId} line item {command.ProductCode} does not exist.");
            }
        }
    }
}
