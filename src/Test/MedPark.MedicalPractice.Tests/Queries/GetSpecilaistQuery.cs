using AutoMapper;
using FluentAssertions;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Handlers.MedicalPractice;
using MedPark.MedicalPractice.Mappings;
using MedPark.MedicalPractice.Queries;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedPark.MedicalPractice.Tests.Queries
{
    public class GetSpecilaistQuery : BaseMedPracticeTest
    {
        public GetSpecilaistQuery()
        {
        }

        [Fact]
        public async Task handle_getspecialistquery_not_null()
        {
            //Arrange
            GetSpecialistHandler handler = new GetSpecialistHandler(_specialistRepo.Object, _mapper);

            GetSpecialist gsQuery = new GetSpecialist();
            gsQuery.Id = Guid.NewGuid();

            //Act
            var result = await handler.HandleAsync(gsQuery);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task handle_getspecialistquery_is_dto()
        {
            //Arrange
            GetSpecialistHandler handler = new GetSpecialistHandler(_specialistRepo.Object, _mapper);

            GetSpecialist gsQuery = new GetSpecialist();
            gsQuery.Id = Guid.NewGuid();

            //Act
            var result = await handler.HandleAsync(gsQuery);

            //Assert
            result.Should().BeOfType<SpecialistDto>();
        }
    }
}
