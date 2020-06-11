using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JaegerOpenTrace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheck : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHealth()
        {
            return await Task.Run(() => Ok($"Jaeger Open Tracing ABrandaoL API Example => {DateTime.UtcNow:o}"));
        }
    }
}
