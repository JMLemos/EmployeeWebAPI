using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Http;
using EmployeeWebApi.DTO;
using System.Linq;
using EmployeeWebApi.Interfaces;
using EmployeeWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeWebApi.Controllers
{
    [ApiController]

    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _repository;
        private readonly List<Employee> _database;  
        private readonly ILogger<EmployeeController> _logger;
        

        public EmployeeController(ILogger<EmployeeController> logger )
        {
            _database = new List<Employee>();
            _logger = logger;

            _repository = new EmployeeRepository(); 
        }

        [HttpGet]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        public async Task <IActionResult> Get([FromQuery] int page, int maxResults)
        {
            var result = await _repository.Get(page, maxResults);

            return Ok (result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _repository.getById(id);

            if (result == null)
                return NotFound("Employee not exist in database");

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var result = await _repository.Insert(employeeDTO);

            return Ok(result);
        }

        [HttpPost("query")]
        
        public async Task<IActionResult> Get(int page, int maxResults, [FromBody] GenderDTO genderDTO)
        {
            var result = _repository.Get(page, maxResults).Result;
            
            var filtered = result.Where(x => x.Gender.Equals(genderDTO.Gender));


            return Ok(filtered);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> UpdateEmployee( int id, EmployeeDTO employeeDTO)
        {
            var search = await _repository.getById(id);

            if (search == null)
                return NotFound("Employee not exist in database");

            var result = await _repository.Update(id, employeeDTO);
           
            return Ok($"Id: {search.Id} was successfully update ");

        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> UpdatePatchEmployee(int id, LoginDTO loginDTO)
        {
            var search = await _repository.getById(id);

            if (search == null)
                return NotFound("Employee not exist in database");

            var result = await _repository.UpdatePatch(id, loginDTO);

            return Ok($"Id: {search.Id} was successfully update ");

        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> DeleteEmployee([FromRoute] int id)
        {
            var search = await _repository.getById(id);

            if (search == null)
                return NotFound("Employee not exist in database");

            var result = await _repository.Delete(id);

            return Ok($"Employee {search.Name} was successfully deleted ");
        }
    }
}