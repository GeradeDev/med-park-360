using AutoMapper;
using MedPark.Common.Handlers;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Queries;
using MedPark.MedicalPractice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.MedicalPractice
{
    public class GetSpecialistHandler : IQueryHandler<GetSpecialist, SpecialistDto>
    {
        private readonly ISpeclialistRepository _specialistRepo;
        private readonly IMapper _mapper;

        public GetSpecialistHandler(ISpeclialistRepository specialistRepo, IMapper mapper)
        {
            _specialistRepo = specialistRepo;
            _mapper = mapper;
        }

        public async Task<SpecialistDto> HandleAsync(GetSpecialist query)
        {
            Specialist specialist = await _specialistRepo.GetAsync(query.Id);

            return _mapper.Map<SpecialistDto>(specialist);
        }
    }
}
