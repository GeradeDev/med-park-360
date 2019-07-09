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
    public class InstituteController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public InstituteController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] InstituteQuery i)
        {
            try
            {
                InstituteDTO institute = await _dispatcher.QueryAsync(i);

                return Ok(institute);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}