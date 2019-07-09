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
    public class OperatingHoursQueryHandler : IQueryHandler<OperatingHoursQuery, OperatingHoursDTO>
    {
        private IMedParkRepository<OperatingHours> _opHoursRepo { get; }
        private IMapper _mapper { get; }

        public OperatingHoursQueryHandler(IMedParkRepository<OperatingHours> opHoursRepo, IMapper mapper)
        {
            _opHoursRepo = opHoursRepo;
            _mapper = mapper;
        }

        public async Task<OperatingHoursDTO> HandleAsync(OperatingHoursQuery query)
        {
            OperatingHours scheme = await _opHoursRepo.GetAsync(query.PracticeId);

            return _mapper.Map<OperatingHoursDTO>(scheme);
        }
    }
}
