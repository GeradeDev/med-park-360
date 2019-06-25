using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Handlers.Customers;
using MedPark.CustomersService.Handlers.Gateway;
using MedPark.CustomersService.Queries;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerService.Tests.Queries
{
    public class CustomerQueries : BaseCustomersTest
    {
        public CustomerQueries()
        {
        }

        [Fact]
        public async Task GetCustomer_Handle_NotNull()
        {
            //Arange
            GetCustomerHandler _handler = new GetCustomerHandler(_customersRepo.Object);

            GetCustomer query = new GetCustomer();
            query.Id = Guid.NewGuid();


            //Act
            CustomerDto customer = await _handler.HandleAsync(query);

            //Assert
            Assert.NotNull(customer);
        }

        [Fact]
        public async Task GetCustomer_Handle_isDto()
        {
            //Arange
            GetCustomerHandler _handler = new GetCustomerHandler(_customersRepo.Object);

            GetCustomer query = new GetCustomer();
            query.Id = Guid.NewGuid();


            //Act
            CustomerDto customer = await _handler.HandleAsync(query);

            //Assert
            Assert.IsType<CustomerDto>(customer);
        }

        [Fact]
        public async Task GetCustomerAddress_Handle_NotNull()
        {
            //Arange
            GetCustomerAddressHandler _handler = new GetCustomerAddressHandler(_addressRepo.Object);

            GetCustomerAddress query = new GetCustomerAddress();
            query.Id = Guid.NewGuid();


            //Act
            List<AddressDto> customer = await _handler.HandleAsync(query);

            //Assert
            Assert.NotNull(customer);
        }

        [Fact]
        public async Task GetCustomerAddress_Handle_isDto()
        {
            //Arange
            GetCustomerAddressHandler _handler = new GetCustomerAddressHandler(_addressRepo.Object);

            GetCustomerAddress query = new GetCustomerAddress();
            query.Id = Guid.NewGuid();


            //Act
            List<AddressDto> customer = await _handler.HandleAsync(query);

            //Assert
            Assert.IsType<AddressDto>(customer[0]);
        }
    }
}
