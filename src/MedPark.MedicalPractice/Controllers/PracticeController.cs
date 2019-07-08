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
    public class PracticeController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public PracticeController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] PracticeQuery practice)
        {
            try
            {
                PracticeDto pDto = await _dispatcher.QueryAsync<PracticeDto>(practice);

                return Ok(pDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getPracticeDetails/{id}")]
        public async Task<IActionResult> GetPracticeDetails([FromRoute] PracticeQuery practice)
        {
            try
            {
                PracticeDetailDTO pDetailDto = await _dispatcher.QueryAsync<PracticeDetailDTO>(practice);

                return Ok(pDetailDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}