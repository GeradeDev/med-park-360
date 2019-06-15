using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.API.Gateway.Services;
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
    }
}