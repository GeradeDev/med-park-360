using AutoMapper;
using MedPark.Common.Dispatchers;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Queries;
using MedPark.CustomersService.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Tests
{
    public class BaseCustomersTest
    {
        public Mock<ICustomerRepository> _customersRepo;
        public Mock<IAddressRepository> _addressRepo;
        public Mock<IMapper> _mapper;
        public Mock<IDispatcher> _dispatcher;

        public BaseCustomersTest()
        {
            _customersRepo = new Mock<ICustomerRepository>();
            _addressRepo = new Mock<IAddressRepository>();
            _mapper = new Mock<IMapper>();
            _dispatcher = new Mock<IDispatcher>();

            SetupRepositories();

            Setup();
        }

        private void SetupRepositories()
        {
            _customersRepo.Setup(s => s.GetAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Customer(Guid.NewGuid(), "")));
            _addressRepo.Setup(s => s.GetAllAsync(It.IsAny<Expression<Func<Address, bool>>>())).Returns(Task.FromResult(new List<Address>() { new Address(Guid.NewGuid(), Guid.NewGuid()) }));
        }

        public void Setup()
        {
            _dispatcher.Setup(s => s.QueryAsync<CustomerDto>(It.IsAny<GetCustomer>())).Returns(Task.FromResult(new CustomerDto { Email = "unit@test.com" }));
        }
    }
}
