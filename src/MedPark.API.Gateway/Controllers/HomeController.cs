using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.API.Gateway.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}