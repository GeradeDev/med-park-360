using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Common.Dispatchers;
using MedPark.MedicalPractice.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.MedicalPractice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public RegistrationController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{otp}")]
        public async Task<IActionResult> Get([FromRoute] GetRegistrationOTP query)
        {
            try
            {
                var s = await _dispatcher.QueryAsync(query);

                return Ok(s);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();
        }
    }
}