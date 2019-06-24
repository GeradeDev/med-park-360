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
    public class BrowseSpecialistsHandler : IQueryHandler<BrowseSpecialists, List<SpecialistDto>>
    {
        private readonly ISpeclialistRepository _specialistRepo;
        private readonly IMapper _mapper;

        public BrowseSpecialistsHandler(ISpeclialistRepository specialistRepo, IMapper mapper)
        {
            _specialistRepo = specialistRepo;
            _mapper = mapper;
        }

        public async Task<List<SpecialistDto>> HandleAsync(BrowseSpecialists query)
        {
            List<Specialist> specialists = await _specialistRepo.BrowseAsync(x => x.PracticeId == query.PracticeId);

            return _mapper.Map<List<SpecialistDto>>(specialists);
        }
    }
}
