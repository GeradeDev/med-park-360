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
    public class SpecialistOperatingHoursQueryHandler : IQueryHandler<SpecialistOperatingHoursQuery, OperatingHoursDTO>
    {
        private IMedParkRepository<Practice> _practiceRepo { get; }
        private IMedParkRepository<OperatingHours> _hoursRepo { get; }
        private IMedParkRepository<Specialist> _specialistRepo { get; }
        private IMapper _mapper { get; }

        public SpecialistOperatingHoursQueryHandler(IMedParkRepository<Practice> practiceRepo, IMedParkRepository<OperatingHours> hoursRepo, IMedParkRepository<Specialist> specialistRepo, IMapper mapper)
        {
            _practiceRepo = practiceRepo;
            _hoursRepo = hoursRepo;
            _specialistRepo = specialistRepo;
            _mapper = mapper;
        }

        public async Task<OperatingHoursDTO> HandleAsync(SpecialistOperatingHoursQuery query)
        {
            OperatingHours specialistHours = await _hoursRepo.GetAsync(x => x.SpecialistId == query.SpecialistId && x.PracticeId == query.PracticeId);

            return _mapper.Map<OperatingHoursDTO>(specialistHours);
        }
    }
}
