using FluentAssertions;
using MedPark.MedicalPractice.Controllers;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MedPark.MedicalPractice.Tests.Controllers
{
    public class SpecialistControllerTests : BaseMedPracticeTest
    {
        private SpecialistController _controller;

        public SpecialistControllerTests()
        {
            _controller = new SpecialistController(_dispatcher.Object);
        }

        [Fact]
        public async Task specialist_controller_get_specialist_DTO()
        {
            //Arrange
            GetSpecialist gs = new GetSpecialist();
            gs.Id = Guid.NewGuid();

            //Act
            var actionResult = await _controller.GetSpecialist(gs);
            var okResult = actionResult as OkObjectResult;

            //Assert
            okResult.Value.Should().NotBeNull();
            var result = okResult.Value.Should().BeAssignableTo<SpecialistDto>();
        }

    }
}
