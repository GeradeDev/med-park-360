using MedPark.API.Gateway.Models;
using MedPark.API.Gateway.Models.MedicalPractice;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IMedicalPracticeService
    {
        [Get("/specialist/{id}")]
        Task<SpecialistDto> GetSpecialist([Path] Guid id);

        [Get("/registration/{otp}")]
        Task<PendingRegistrationDto> GetRegistrationOTP([Path] Int32 otp);
    }
}
