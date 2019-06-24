using FluentAssertions;
using MedPark.CustomersService.Controllers;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerService.Tests.Controllers
{
    public class CustomersControllerTest : BaseCustomersTest
    {
        private CustomersController controller;

        public CustomersControllerTest()
        {
            controller = new CustomersController(_customersRepo.Object, _mapper.Object, _dispatcher.Object);
        }

        [Fact]
        public async Task CustomersController_Get()
        {
            //Arrange
            GetCustomer gc = new GetCustomer();
            gc.Id = Guid.NewGuid();

            //Act
            var result = await controller.Get(gc);
            var contentResult = result as ActionResult<CustomerDto>;

            //Assert
            contentResult.Should().NotBeNull();
        }

        [Fact]
        public async Task CustomersController_GetAll()
        {
            //Arrange
            GetCustomer gc = new GetCustomer();
            gc.Id = Guid.NewGuid();

            //Act
            var result = await controller.Get(gc);
            var contentResult = result as ActionResult<CustomerDto>;

            //Assert
            contentResult.Should().NotBeNull();
        }
    }
}
