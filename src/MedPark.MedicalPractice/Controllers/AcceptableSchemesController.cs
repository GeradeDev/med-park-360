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
    public class AcceptableSchemesController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AcceptableSchemesController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{practiceid}")]
        public async Task<IActionResult> Get([FromRoute] AcceptedMedicalSchemeQuery ams)
        {
            try
            {
                List<AcceptedMedicalSchemeDTO> schemes = await _dispatcher.QueryAsync(ams);

                return Ok(schemes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getscheme/{schemeid}")]
        public async Task<IActionResult> GetSchemeById([FromRoute] AcceptedMedicalSchemeQuery query)
        {
            try
            {
                var scheme = await _dispatcher.QueryAsync(query);

                return Ok(scheme.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}