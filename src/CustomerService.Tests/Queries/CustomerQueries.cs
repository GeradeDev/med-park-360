using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Handlers.Customers;
using MedPark.CustomersService.Handlers.Gateway;
using MedPark.CustomersService.Queries;
using MedPark.CustomersService.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerService.Tests.Queries
{
    public class CustomerQueries
    {
        public Mock<ICustomerRepository> _custRepo;
        public Mock<IAddressRepository> _addrRepo;

        public CustomerQueries()
        {
            _custRepo = new Mock<ICustomerRepository>();
            _addrRepo = new Mock<IAddressRepository>();

            Setup();
        }
        
        public void Setup()
        {
            _custRepo.Setup(s => s.GetAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Customer(Guid.NewGuid(), "")));

            _addrRepo.Setup(s => s.GetAllAsync(It.IsAny<Expression<Func<Address, bool>>>())).Returns(Task.FromResult(new List<Address>() { new Address(Guid.NewGuid(), Guid.NewGuid()) }));
            
        }

        [Fact]
        public async Task GetCustomerQuery_GetCustomer_isDto()
        {
            //Arange
            GetCustomerHandler _handler = new GetCustomerHandler(_custRepo.Object);

            GetCustomer query = new GetCustomer();
            query.Id = Guid.NewGuid();


            //Act
            CustomerDto customer = await _handler.HandleAsync(query);

            //Assert
            Assert.IsType<CustomerDto>(customer);
        }

        [Fact]
        public async Task GetCustomerQuery_GetCustomerAddress_isDto()
        {
            //Arange
            GetCustomerAddressHandler _handler = new GetCustomerAddressHandler(_addrRepo.Object);

            GetCustomerAddress query = new GetCustomerAddress();
            query.Id = Guid.NewGuid();


            //Act
            List<AddressDto> customer = await _handler.HandleAsync(query);

            //Assert
            Assert.IsType<AddressDto>(customer[0]);
        }
    }
}
