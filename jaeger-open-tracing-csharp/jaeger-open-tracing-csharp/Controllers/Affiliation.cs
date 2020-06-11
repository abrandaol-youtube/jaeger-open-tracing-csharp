using System;
using System.Diagnostics;
using System.Linq;
using Core;
using JaegerOpenTrace.Domain;
using JaegerOpenTrace.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTracing;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Affiliation : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<Affiliation> _logger;
        private readonly ITracer _tracer;

        public Affiliation(ICustomerRepository customerRepository, ILogger<Affiliation> logger, ITracer tracer)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _tracer = tracer;
        }

        [HttpPost]
        public IActionResult Insert(Customer customer)
        {
            try
            {
                using var scope = _tracer.BuildSpan("DatabaseInsert").StartActive(true);

                if (new CustomerValidation().Validate(customer, _tracer))
                {

                    _customerRepository.Insert(customer);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro no request de cadastro de cliente", ex);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                return Ok(_customerRepository.Query());
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro no request de cadastro de cliente", ex);
                return new StatusCodeResult(500);
            }
        }
    }
}
