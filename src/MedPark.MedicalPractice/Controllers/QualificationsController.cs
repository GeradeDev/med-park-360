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
    public class QualificationsController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public QualificationsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{specialistid}")]
        public async Task<IActionResult> Get([FromRoute] SpecialistQualificationsQuery qualificationsQuery)
        {
            try
            {
                SpecialistQualificationDTO qualification = await _dispatcher.QueryAsync(qualificationsQuery);

                return Ok(qualification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}