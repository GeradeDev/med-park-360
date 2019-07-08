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
    public class PracticeQueryHandler : IQueryHandler<PracticeQuery, PracticeDto>
    {
        private IMedParkRepository<Practice> _practiceRepo { get; }
        private IMapper _mapper { get; }

        public PracticeQueryHandler(IMedParkRepository<Practice> practiceRepo, IMapper mapper)
        {
            _practiceRepo = practiceRepo;
            _mapper = mapper;
        }

        public async Task<PracticeDto> HandleAsync(PracticeQuery query)
        {
            var p = await _practiceRepo.GetAsync(x => x.Id == query.Id);

            return _mapper.Map<PracticeDto>(p);
        }
    }
}
