using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.Payment.Domain;
using MedPark.Payment.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Handlers.OrderService
{
    public class OrderPlacedHandler : IEventHandler<OrderPlaced>
    {
        private IMedParkRepository<Customer> _buyerRepo { get; }
        private IMedParkRepository<OrderPayment> _orderPaymentRepo { get; }

        public OrderPlacedHandler(IMedParkRepository<Customer> buyerRepo, IMedParkRepository<OrderPayment> orderPaymentRepo)
        {
            _buyerRepo = buyerRepo;
            _orderPaymentRepo = orderPaymentRepo;
        }

        public async Task HandleAsync(OrderPlaced @event, ICorrelationContext context)
        {
            Customer buyer = await _buyerRepo.GetAsync(@event.BuyerId);

            if (buyer is null)
                throw new MedParkException("customer_does_not_exist", $"Buyer {@event.BuyerId} does not exist.");

            OrderPayment op = new OrderPayment(Guid.NewGuid());

            op.Create(@event.OrderId, @event.BuyerId, @event.OrderTotal);

            //Validate
            op.Use();

            await _orderPaymentRepo.AddAsync(op);
        }
    }
}
