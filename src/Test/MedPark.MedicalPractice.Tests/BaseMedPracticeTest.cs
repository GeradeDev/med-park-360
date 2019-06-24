using AutoMapper;
using MedPark.Common.Dispatchers;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Handlers.MedicalPractice;
using MedPark.MedicalPractice.Mappings;
using MedPark.MedicalPractice.Queries;
using MedPark.MedicalPractice.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Tests
{
    public class BaseMedPracticeTest
    {
        public IMapper _mapper;
        public Mock<IDispatcher> _dispatcher;

        public Mock<ISpeclialistRepository> _specialistRepo;

        public BaseMedPracticeTest()
        {
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MedicalPracticeMappings());
            });

            _mapper = mockMapper.CreateMapper();

            _dispatcher = new Mock<IDispatcher>();

            _specialistRepo = new Mock<ISpeclialistRepository>();
            SetupRepositories();

            Setup();
        }

        private void SetupRepositories()
        {
            _specialistRepo.Setup(r => r.GetAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Specialist(Guid.NewGuid())));
            _specialistRepo.Setup(r => r.UpdateAsync(It.IsAny<Specialist>())).Returns(Task.FromResult(new Specialist(Guid.NewGuid())));
            _specialistRepo.Setup(r => r.DeleteAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Specialist(Guid.NewGuid())));
            _specialistRepo.Setup(r => r.AddAsync(It.IsAny<Specialist>())).Returns(Task.FromResult(new Specialist(Guid.NewGuid())));
            _specialistRepo.Setup(r => r.BrowseAsync(It.IsAny<Expression<Func<Specialist, bool>>>())).Returns(Task.FromResult(new List<Specialist> { new Specialist(Guid.NewGuid()) }));
        }

        public void Setup()
        {

            _dispatcher.Setup(s => s.QueryAsync<SpecialistDto>(It.IsAny<GetSpecialist>())).Returns(Task.FromResult(new SpecialistDto { }));
        }
    }
}
