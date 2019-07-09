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
    public class MedicalSchemeQueryHandler : IQueryHandler<MedicalSchemeQuery, MedicalSchemeDTO>
    {
        private IMedParkRepository<MedicalScheme> _schemesRepo { get; }
        private IMapper _mapper { get; }

        public MedicalSchemeQueryHandler(IMedParkRepository<MedicalScheme> schemesRepo, IMapper mapper)
        {
            _schemesRepo = schemesRepo;
            _mapper = mapper;
        }

        public async Task<MedicalSchemeDTO> HandleAsync(MedicalSchemeQuery query)
        {
            MedicalScheme scheme = await _schemesRepo.GetAsync(query.SchemeId);

            return _mapper.Map<MedicalSchemeDTO>(scheme);
        }
    }
}
