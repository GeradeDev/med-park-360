using MedPark.Identity.Models.MedicalPracticeService;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Identity.Services
{
    public interface IMedicalPracticeService
    {
        [Get("/registration/{otp}")]
        Task<PendingRegistrationDto> GetRegistrationOTPDetails([Path] string otp);
    }
}
