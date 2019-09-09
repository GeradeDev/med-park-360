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
    public class AcceptedMedicalSchemeQueryHandler : IQueryHandler<AcceptedMedicalSchemeQuery, List<AcceptedMedicalSchemeDTO>>
    {
        private IMedParkRepository<AcceptedMedicalScheme> _medSchemeRepo { get; }
        private IMapper _mapper { get; }

        public AcceptedMedicalSchemeQueryHandler(IMedParkRepository<AcceptedMedicalScheme> medSchemeRepo, IMapper mapper)
        {
            _medSchemeRepo = medSchemeRepo;
            _mapper = mapper;
        }

        public async Task<List<AcceptedMedicalSchemeDTO>> HandleAsync(AcceptedMedicalSchemeQuery query)
        {
            List<AcceptedMedicalSchemeDTO> result = new List<AcceptedMedicalSchemeDTO>();

            if (query.PracticeId != Guid.Empty)
            {
                var ams = await _medSchemeRepo.FindAsync(x => x.PracticeId == query.PracticeId);

                result = _mapper.Map<List<AcceptedMedicalSchemeDTO>>(ams.ToList());
            }
            else
            {
                var scheme = await _medSchemeRepo.GetAsync(query.SchemeId);
                var schemeDto = _mapper.Map<AcceptedMedicalSchemeDTO>(scheme);

                result.Add(schemeDto);
            }

            return result;
        }
    }
}
