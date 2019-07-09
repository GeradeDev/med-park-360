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
    public class AcceptedMedicalSchemeQueryHandler : IQueryHandler<AcceptedMedicalSchemeQuery, AcceptedMedicalSchemeDTO>
    {
        private IMedParkRepository<AcceptedMedicalScheme> _medSchemeRepo { get; }
        private IMapper _mapper { get; }

        public AcceptedMedicalSchemeQueryHandler(IMedParkRepository<AcceptedMedicalScheme> medSchemeRepo, IMapper mapper)
        {
            _medSchemeRepo = medSchemeRepo;
            _mapper = mapper;
        }

        public async Task<AcceptedMedicalSchemeDTO> HandleAsync(AcceptedMedicalSchemeQuery query)
        {
            AcceptedMedicalScheme ams = await _medSchemeRepo.GetAsync(query.PracticeId);

            return _mapper.Map<AcceptedMedicalSchemeDTO>(ams);
        }
    }
}
