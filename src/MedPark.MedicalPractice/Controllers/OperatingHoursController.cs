using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Common.Dispatchers;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.MedicalPractice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperatingHoursController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public OperatingHoursController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("specialistpracticehours/{practiceid}/{specialistid}")]
        public async Task<IActionResult> GetSpecialistPracticeHoursDetails([FromRoute] SpecialistOperatingHoursQuery hoursQuery)
        {
            try
            {
                OperatingHoursDTO hours = await _dispatcher.QueryAsync(hoursQuery);

                return Ok(hours);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}