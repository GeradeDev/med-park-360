using FluentAssertions;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Handlers.MedicalPractice;
using MedPark.MedicalPractice.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MedPark.MedicalPractice.Tests.Queries
{
    public class BrowseSpecialistsTest : BaseMedPracticeTest
    {
        [Fact]
        public void handle_browsespecialists_not_null()
        {
            BrowseSpecialistsHandler _handler = new BrowseSpecialistsHandler(_specialistRepo.Object, _mapper);

            BrowseSpecialists query = new BrowseSpecialists();
            query.PracticeId = Guid.NewGuid();

            var result = _handler.HandleAsync(query);

            //Assert
            result.Should().NotBeNull();
        }
    }
}
