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
    public class GetRegistrationOTPHandler : IQueryHandler<GetRegistrationOTP, PendingRegistrationDto>
    {
        private IMedParkRepository<PendingRegistration> _pendingRegistrationsRepo { get; }
        private IMapper _mapper { get; }

        public GetRegistrationOTPHandler(IMedParkRepository<PendingRegistration> pendingRegistrationsRepo, IMapper mapper)
        {
            _pendingRegistrationsRepo = pendingRegistrationsRepo;
            _mapper = mapper;
        }

        public async Task<PendingRegistrationDto> HandleAsync(GetRegistrationOTP query)
        {
            var pendingRegistration = await _pendingRegistrationsRepo.GetAsync(x => x.OTP == query.OTP);

            return _mapper.Map<PendingRegistrationDto>(pendingRegistration);
        }
    }
}
