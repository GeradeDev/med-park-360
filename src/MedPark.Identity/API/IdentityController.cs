using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.Identity.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private ApplicationUserContext _appUserContext { get; }

        public IdentityController(ApplicationUserContext appUserContext)
        {
            _appUserContext = appUserContext;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            try
            {
                var user = _appUserContext.Users.Where(x => x.IdentityId == userId).FirstOrDefault();

                return Ok(user);
            }
            catch { }

            return BadRequest();
        }
    }
}