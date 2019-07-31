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
    public class UpdateOrderShippingHandler : ICommandHandler<UpdateOrderShipping>
    {
        private IMedParkRepository<Order> _orderRepo { get; }
        private IMedParkRepository<CustomerAddress> _addressRepo { get; }

        public UpdateOrderShippingHandler(IMedParkRepository<Order> orderRepo, IMedParkRepository<CustomerAddress> addressRepo)
        {
            _orderRepo = orderRepo;
            _addressRepo = addressRepo;
        }

        public async Task HandleAsync(UpdateOrderShipping command, ICorrelationContext context)
        {
            Order o = await _orderRepo.GetAsync(command.OrderId);

            if (o is null)
                throw new MedParkException("update_item_order_does_not_exist", $"Order {command.OrderId} does not exist.");

            if(command.ShippingType == (int)MedParkEnums.OrderShippingType.Collection)
            {
                //Collection
                CustomerAddress addrs = await _addressRepo.GetAsync(x => x.IsPickUpLocation.HasValue && x.Id == command.AddressId);

                o.SetShipping(command.ShippingType, addrs.Id);

                await _orderRepo.UpdateAsync(o);
            }
            else
            {
                //Delivery
                CustomerAddress addrs = await _addressRepo.GetAsync(command.AddressId);

                if (addrs is null)
                    throw new MedParkException("buyer_address_does_not_exist", $"Address {command.AddressId} does not exist.");

                o.SetShipping(command.ShippingType, addrs.Id);

                await _orderRepo.UpdateAsync(o);
            }
        }
    }
}
