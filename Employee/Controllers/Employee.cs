using EmployeesLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            try
            {
                var employees = await _employeeService.GetEmployeeByNameAsync(name);

                if (employees.Count == 0)
                {
                    return NotFound("Employee not found");
                }

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
