using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly IInformationRepository _informationRepository;

        public InformationController(IInformationRepository informationRepository)
        {
            _informationRepository = informationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHealth()
        {
            return await Task.Run(() => Ok(_informationRepository.GetData()));
        }
    }
}
