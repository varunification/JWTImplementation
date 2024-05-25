using JWTImplementation.Interfaces;
using JWTImplementation.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
                _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
           var employees = _employeeService.GetEmployeeDetails();
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var employee = _employeeService.GetEmployeeDetails(id);
            return employee;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public Employee Post([FromBody] Employee value)
        {
            var emp = _employeeService.AddEmployee(value);
            return emp;

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            var VALUE = _employeeService.Update(value);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var isdeleted = _employeeService.deleteEmployee(id);
            return isdeleted;
        }
    }
}
