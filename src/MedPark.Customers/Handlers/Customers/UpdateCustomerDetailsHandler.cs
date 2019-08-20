using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Messages.Commands;
using MedPark.CustomersService.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Handlers.Customers
{
    public class UpdateCustomerDetailsHandler : ICommandHandler<UpdateCustomerDetails>
    {
        private IMedParkRepository<Customer> _customerRepo { get; }
        private IBusPublisher _busPublisher { get; }

        public UpdateCustomerDetailsHandler(IMedParkRepository<Customer> customerRepo, IBusPublisher busPublisher)
        {
            _customerRepo = customerRepo;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(UpdateCustomerDetails command, ICorrelationContext context)
        {
            var customer = await _customerRepo.GetAsync(x => x.Id == command.Id);

            if (customer == null)
            {
                throw new MedParkException("customer_does_not_exists", $"Customer account with id '{command.Id}' does not exist.");
            }

            customer.SetNames(command.FirstName, command.LastName);
            customer.SetEmail(command.Email);
            customer.SetCustomerBirthday(command.DOB);
            customer.SetCustomerMobile(command.Mobile);

            customer.Use();

            await _customerRepo.UpdateAsync(customer);


            //Publish update to other services
            CustomerDetailsUpated updatedEvent = new CustomerDetailsUpated(customer.Id, command.FirstName, command.LastName, command.Email, command.Mobile);
            await _busPublisher.PublishAsync(updatedEvent, CorrelationContext.Empty);
        }
    }
}
