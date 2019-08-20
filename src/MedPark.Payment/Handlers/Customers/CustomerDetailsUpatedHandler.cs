﻿using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.Payment.Domain;
using MedPark.Payment.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Handlers.Customers
{
    public class CustomerDetailsUpatedHandler : IEventHandler<CustomerDetailsUpated>
    {
        private IMedParkRepository<Customer> _customer { get; }

        public CustomerDetailsUpatedHandler(IMedParkRepository<Customer> customer)
        {
            _customer = customer;
        }

        public async Task HandleAsync(CustomerDetailsUpated @event, ICorrelationContext context)
        {
            Customer cust = await _customer.GetAsync(@event.Id);

            if (cust == null)
                throw new MedParkException("", "");

            cust.UpdateDetails(@event.FirstName, @event.LastName);

            cust.Use();

            await _customer.UpdateAsync(cust);
        }
    }
}
