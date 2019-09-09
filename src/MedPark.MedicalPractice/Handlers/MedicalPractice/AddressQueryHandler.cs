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
    public class AddressQueryHandler : IQueryHandler<AddressQuery, PracticeAddressDTO>
    {
        private IMedParkRepository<Address> _practiceAddressRepo { get; }
        private IMapper _mapper { get; }

        public AddressQueryHandler(IMedParkRepository<Address> practiceAddressRepo, IMapper mapper)
        {
            _practiceAddressRepo = practiceAddressRepo;
            _mapper = mapper;
        }

        public async Task<PracticeAddressDTO> HandleAsync(AddressQuery query)
        {
            Address addr = null;

            if (query.Id != Guid.Empty)
                addr = await _practiceAddressRepo.GetAsync(query.Id);
            else
            {
                addr = await _practiceAddressRepo.GetAsync(x => x.PracticeId == query.PracticeId);
            }

            return _mapper.Map<PracticeAddressDTO>(addr);
        }
    }
}
