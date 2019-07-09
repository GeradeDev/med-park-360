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

namespace MedPark.MedicalPractice.Handlers
{
    public class PracticeDetailQueryHandler : IQueryHandler<PracticeQuery, PracticeDetailDTO>
    {
        private IMedParkRepository<Practice> _practiceRepo { get; }
        private IMedParkRepository<Address> _addressRepo { get; }
        private IMedParkRepository<Specialist> _specialistRepo { get; }
        private IMedParkRepository<OperatingHours> _opHoursRepo { get; }

        private IMapper _mapper { get; }
        
        public PracticeDetailQueryHandler(IMedParkRepository<Practice> practiceRepo, IMapper mapper, IMedParkRepository<Address> addressRepo, IMedParkRepository<Specialist> specialistRepo, IMedParkRepository<OperatingHours> opHoursRepo)
        {
            _practiceRepo = practiceRepo;
            _mapper = mapper;
            _addressRepo = addressRepo;
            _specialistRepo = specialistRepo;
            _opHoursRepo = opHoursRepo;
        }

        public async Task<PracticeDetailDTO> HandleAsync(PracticeQuery query)
        {
            var prac = await _practiceRepo.GetAsync(query.Id);

            if (prac != null)
            {
                PracticeDetailDTO result = new PracticeDetailDTO();

                var mappedPractice = _mapper.Map<PracticeDto>(prac);
                result.Practice = mappedPractice;

                //Get the addresses
                var addrs = await _addressRepo.FindAsync(x => x.PracticeId == query.Id);
                var mappedAddrs = _mapper.Map<IEnumerable<Address>, IEnumerable<PracticeAddressDTO>>(addrs);
                result.Addresses = mappedAddrs.ToList();

                //Get the specialists for practice
                var specs = await _specialistRepo.FindAsync(x => x.PracticeId == query.Id);
                var mappedSpecialists = _mapper.Map< IEnumerable<Specialist>, IEnumerable <SpecialistDto>>(specs);
                result.Specialists = mappedSpecialists.ToList();

                //Get Practice operating hours
                var opHours = await _opHoursRepo.GetAsync(query.Id);
                var mappedHours = _mapper.Map<OperatingHoursDTO>(opHours);
                result.OperatingHours = mappedHours;

                return result;
            }

            return null;
        }
    }
}
