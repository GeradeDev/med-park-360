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
    [Route("specialist")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        
        public SpecialistController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialist([FromRoute] GetSpecialist query)
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