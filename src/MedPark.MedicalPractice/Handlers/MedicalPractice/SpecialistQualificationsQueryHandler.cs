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
    public class SpecialistQualificationsQueryHandler : IQueryHandler<SpecialistQualificationsQuery, SpecialistQualificationDTO>
    {
        private IMedParkRepository<Qualifications> _qualificationsRepo { get; }
        private IMapper _mapper { get; }

        public SpecialistQualificationsQueryHandler(IMedParkRepository<Qualifications> qualificationsRepo, IMapper mapper)
        {
            _qualificationsRepo = qualificationsRepo;
            _mapper = mapper;
        }

        public async Task<SpecialistQualificationDTO> HandleAsync(SpecialistQualificationsQuery query)
        {
            Qualifications qualification = await _qualificationsRepo.GetAsync(query.SpecialistId);

            return _mapper.Map<SpecialistQualificationDTO>(qualification);
        }
    }
}
