using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBDKol1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBDKol1.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    { 
        IDbService service;
        public PrescriptionsController(IDbService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult Get(string lastName) {
            

            return Ok(service.GetPrescriptions(lastName));
        }

    }
}