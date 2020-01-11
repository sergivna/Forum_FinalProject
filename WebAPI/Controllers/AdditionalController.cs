using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AdditionalController : ControllerBase
    {
        private readonly IAdditionalService additionalService;
        public AdditionalController(IAdditionalService additionalService)
        {
            this.additionalService = additionalService;
        }

        [HttpGet("country")]
        public async Task<IActionResult> GetCountries()
        {
            var result =  await additionalService.GetCountries();
            return Ok(result);
        }
    }
}