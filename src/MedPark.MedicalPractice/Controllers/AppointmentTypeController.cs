using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Common.Dispatchers;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Handlers.MedicalPractice;
using MedPark.MedicalPractice.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.MedicalPractice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentTypeController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AppointmentTypeController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromRoute] AppointmentTypeQuery query)
        {
            return Ok(await _dispatcher.QueryAsync<List<AppointmentTypeDTO>>(query));
        }

        [HttpGet("getBySpecialist/{specialistid}")]
        public async Task<IActionResult> GetBySpecialistId([FromRoute] AppointmentTypeQuery query)
        {
            return Ok(await _dispatcher.QueryAsync<SpecialistAppointmentTypesDTO>(query));
        }

        [HttpGet("getbyid/{appointmenttypeid}")]
        public async Task<IActionResult> GetById([FromRoute] AppointmentTypeQuery query)
        {
            return Ok(await _dispatcher.QueryAsync<SpecialistAppointmentTypesDTO>(query));
        }

        [HttpGet("getSpecialistByAppointment/{appointmenttypeid}")]
        public async Task<IActionResult> GetSpecialistByAppointmentType([FromRoute] SpecialistsLinkedToAppointmentTypeQuery query)
        {
            return Ok(await _dispatcher.QueryAsync<AppointmentTypeSpecialistDTO>(query));
        }
    }
}