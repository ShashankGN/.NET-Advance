using Employees.API.Contracts;
using Employees.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        
        [HttpGet]
        public IActionResult GetEmployees() {
            var employees= _employee.GetEmployees();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployees([FromBody] Employee employee)
        {
            var addEmployee = _employee.AddEmployee(employee);
            return Ok(addEmployee);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeByID([FromRoute]int id)
        {
            var employee=_employee.GetEmployeeById(id);
            if(employee == null)
            {
                return NotFound($"Employee with id {id} is not found");
            }
            return Ok(employee);    
        }

        [HttpPut("{id}")]
        public IActionResult updateEmployee([FromRoute]int id, [FromBody] Employee employee)
        {
            var update=_employee.UpdateEmployee(id,employee);
            if (update)
            {
                return Ok(update);
            }
            return NotFound($"Employee with id {id} is not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute]int id)
        {
            var employee=_employee.DeleteEmployee(id);
            if (employee)
            {
                return Ok($"employee with id {id} is deleted successfully");
            }
            return NotFound($"Employee with id {id} is not found");
        }


    }
}
