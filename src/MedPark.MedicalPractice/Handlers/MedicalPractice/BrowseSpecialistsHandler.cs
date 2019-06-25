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
    public class BrowseSpecialistsHandler : IQueryHandler<BrowseSpecialists, List<SpecialistDto>>
    {
        private IMedParkRepository<Specialist> _specialistRepo { get; }
        private readonly IMapper _mapper;

        public BrowseSpecialistsHandler(IMedParkRepository<Specialist> specialistRepo, IMapper mapper)
        {
            _specialistRepo = specialistRepo;
            _mapper = mapper;
        }

        public async Task<List<SpecialistDto>> HandleAsync(BrowseSpecialists query)
        {
            var specialists = await _specialistRepo.BrowseAsync(x => x.PracticeId == query.PracticeId);

            return _mapper.Map<List<SpecialistDto>>(specialists.ToList());
        }
    }
}
