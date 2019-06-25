using AutoMapper;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.MedicalPractice
{
    public class GetSpecialistHandler : IQueryHandler<GetSpecialist, SpecialistDto>
    {
        private IMedParkRepository<Specialist> _specialistRepo { get; }
        private readonly IMapper _mapper;

        public GetSpecialistHandler(IMedParkRepository<Specialist> specialistRepo, IMapper mapper)
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
