using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Bookings.Dto;
using MedPark.Bookings.Queries;
using MedPark.Common.Dispatchers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.Bookings.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AppointmentsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("getspecialistappointments/{specialistid}")]
        public async Task<IActionResult> GetSpecialistAppointments([FromRoute] AppointmentQuery query)
        {
            try
            {
                SpecialistAppointmentsDto bookings = await _dispatcher.QueryAsync<SpecialistAppointmentsDto>(query);

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getpatientappointments/{customerid}")]
        public async Task<IActionResult> GetCustomerAppointments([FromRoute] AppointmentQuery query)
        {
            try
            {
                CustomerAppointmentsDto patientBookings = await _dispatcher.QueryAsync<CustomerAppointmentsDto>(query);

                return Ok(patientBookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{appointmentid}/details")]
        public async Task<IActionResult> GetCustomerAppointments([FromRoute] AppointmentDetailQuery query)
        {
            try
            {
                AppointmentDetailDto appointment = await _dispatcher.QueryAsync<AppointmentDetailDto>(query);

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}