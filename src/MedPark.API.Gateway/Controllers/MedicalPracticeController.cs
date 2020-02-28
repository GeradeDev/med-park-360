using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.API.Gateway.Messages.Commands;
using MedPark.API.Gateway.Services;
using MedPark.Common;
using MedPark.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.API.Gateway.Controllers
{
    [Route("api/specialist")]
    [ApiController]
    public class MedicalPracticeController : ControllerBase
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IMedicalPracticeService _specialistService;

        public MedicalPracticeController(IBusPublisher busPublisher, IMedicalPracticeService specialistService)
        {
            _busPublisher = busPublisher;
            _specialistService = specialistService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialistDetails(Guid id)
        {
            var specialist = await _specialistService.GetSpecialist(id);

            return Ok(specialist);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateSpecialistDetails(UpdateSpecialistDetails command)
        {
            await _busPublisher.SendAsync(command, null);

            return Accepted();
        }

        [HttpGet("getregistrationotp/{otp}")]
        public async Task<IActionResult> GetRegistrationOtp(Int32 otp)
        {
            var otpDetails = await _specialistService.GetRegistrationOTP(otp);

            return Ok(otpDetails);
        }
        
        [HttpPost("addregistrationotp")]
        public async Task<IActionResult> AddAddress(AddPendingRegistration command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.Id, Guid.NewGuid()), null);

            return Accepted();
        }

        [HttpGet("getpractice/{id}")]
        public async Task<IActionResult> GetPractice(Guid id)
        {
            var practice = await _specialistService.GetPracticeById(id);

            return Ok(practice);
        }

        [HttpPost("addaddress")]
        public async Task<IActionResult> AddAddress(AddAddress command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.Id, Guid.NewGuid()), null);

            return Accepted();
        }

        [HttpPost("updateaddress")]
        public async Task<IActionResult> UpdateAddress(UpdateAddress command)
        {
            await _busPublisher.SendAsync(command, null);

            return Accepted();
        }

        [HttpGet("getpracticedetails/{id}")]
        public async Task<IActionResult> GetPracticeDetails(Guid id)
        {
            var practiceDetails = await _specialistService.GetPracticeDetailById(id);

            return Ok(practiceDetails);
        }

        [HttpGet("getacceptedschemes/{practiceId}")]
        public async Task<IActionResult> GetAcceptedSchemes(Guid practiceId)
        {
            var acceptedSchemesByPractice = await _specialistService.GetAcceptedSchemesByPracticeId(practiceId);

            return Ok(acceptedSchemesByPractice);
        }

        [HttpPost("addacceptedscheme")]
        public async Task<IActionResult> AddAcceptedScheme(AddPracticeAcceptedMedicalScheme command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.Id, Guid.NewGuid()).Bind(x => x.DateEffective, DateTime.Now).Bind(X => X.DateEnd, DateTime.Now.AddYears(1)), null);

            return Accepted();
        }

        [HttpPost("updateacceptedscheme")]
        public async Task<IActionResult> UpdateAcceptedScheme(UpdatePracticeAcceptedMedicalScheme command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.DateEffective, DateTime.Now).Bind(X => X.DateEnd, DateTime.Now.AddYears(2)), null);

            return Accepted();
        }

        [HttpPost("removeacceptedscheme")]
        public async Task<IActionResult> RemoveAcceptedScheme(RemoveAcceptedMedicalScheme command)
        {
            await _busPublisher.SendAsync(command, null);

            return Accepted();
        }

        [HttpGet("getinstitute/{id}")]
        public async Task<IActionResult> GetInstitute(Guid id)
        {
            var institute = await _specialistService.GetInstituteById(id);

            return Ok(institute);
        }

        [HttpPost("addinstitute")]
        public async Task<IActionResult> AddInstitute(AddInstitute command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.Id, Guid.NewGuid()), null);

            return Accepted();
        }

        [HttpGet("getmedicalscheme/{schemeid}")]
        public async Task<IActionResult> GetMedicalScheme(Guid schemeid)
        {
            var scheme = await _specialistService.GetInstituteById(schemeid);

            return Ok(scheme);
        }

        [HttpPost("addmedicalscheme")]
        public async Task<IActionResult> AddMedicalScheme(AddMedicalScheme command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.Id, Guid.NewGuid()), null);

            return Accepted();
        }
        
        [HttpPost("setpracticeoperatinghours")]
        public async Task<IActionResult> SetPracticeHours(AddOperatingHours command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.Id, Guid.NewGuid()), null);

            return Accepted();
        }

        [HttpPost("updateoperatinghours")]
        public async Task<IActionResult> UpdatePracticeHours(UpdateOperatingHours command)
        {
            await _busPublisher.SendAsync(command, null);

            return Accepted();
        }

        [HttpGet("specialistqualifications/{specialistid}")]
        public async Task<IActionResult> GetSpecialistQualifications(Guid specialistid)
        {
            var qualifications = await _specialistService.GetSpecialistQualifications(specialistid);

            return Ok(qualifications);
        }

        [HttpPost("addqualification")]
        public async Task<IActionResult> AddSpecialistQualifications(AddQualification command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.Id, Guid.NewGuid()), null);

            return Accepted();
        }

        [HttpPost("removequalification")]
        public async Task<IActionResult> DeleteSpecialistQualifications(RemoveQualification command)
        {
            await _busPublisher.SendAsync(command, null);

            return Accepted();
        }

        [HttpGet("appointmenttypes")]
        public async Task<IActionResult> AddSpecialistQualifications()
        {
            var appTypes = await _specialistService.GetAllAppointmentTypes();

            return Ok(appTypes);
        }

        [HttpGet("appointmenttypes/{specialistid}")]
        public async Task<IActionResult> DeleteSpecialistQualifications(Guid specialistid)
        {
            var appTypes = await _specialistService.GetAppointmentTypesBySpecialistId(specialistid);

            return Ok(appTypes);
        }

        [HttpPost("linkspecialistappointments")]
        public async Task<IActionResult> LinkSpecialistToAppointmentType(LinkSpecialistAppointmentType command)
        {
            await _busPublisher.SendAsync(command, null);

            return Accepted();
        }

        [HttpGet("specialistsLinkedToAppointmentType/{appointmenttypeid}")]
        public async Task<IActionResult> LinkSpecialistToAppointmentType(Guid appointmenttypeid)
        {
            var specialists = await _specialistService.GetSpecialistByAppointmentType(appointmenttypeid);

            return Ok(specialists);
        }
        
        [HttpGet("specialistpracticeHours/{practiceid}/{specialistid}")]
        public async Task<IActionResult> GetSpecialistOperatingHours(Guid practiceid, Guid specialistid)
        {
            var hours = await _specialistService.GetSpecialistPracticeHoursDetails(practiceid, specialistid);

            return Ok(hours);
        }
    }
}