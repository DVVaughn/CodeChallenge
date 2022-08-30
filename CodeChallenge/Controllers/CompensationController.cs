using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    /// <summary>
    /// The controller responsible for routing related to Compensation
    /// </summary>
    [ApiController]
    [Route("api/employee/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger; 
        private readonly ICompensationService _compensationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="compensationService"></param>
        public CompensationController(ILogger<EmployeeController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        /// <summary>
        /// Creates the compensation object
        /// </summary>
        /// <param name="compensation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received compensation create request for '{compensation?.Employee?.FirstName} {compensation?.Employee?.LastName}'");

            _compensationService.Create(compensation);

            return CreatedAtRoute("getCompByEmployeeId", new { id = compensation?.Employee?.EmployeeId }, compensation);
        }

        /// <summary>
        /// Gets a compensation object based on the EmployeeId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "getCompByEmployeeId")]
        public IActionResult GetCompByEmployeeId(String id)
        {
            _logger.LogDebug($"Received compensation get request for employee id: '{id}'");

            // Get the compensation based on employee id
            var comp = _compensationService.GetByEmployeeId(id);

            // IF(Compensation was not found, then  return NotFound result)
            if (comp == null)
                return NotFound();

            return Ok(comp);
        }
    }
}
