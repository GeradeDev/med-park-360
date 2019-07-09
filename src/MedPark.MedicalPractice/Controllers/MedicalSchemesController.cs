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
    public class MedicalSchemesController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public MedicalSchemesController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{schemeid}")]
        public async Task<IActionResult> Get([FromRoute] MedicalSchemeQuery msQuery)
        {
            try
            {
                MedicalSchemeDTO ms = await _dispatcher.QueryAsync(msQuery);

                return Ok(ms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}