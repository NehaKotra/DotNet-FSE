using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Handson5.Models;

namespace WebApi_Handson5.Controllers
{
    [ApiController]

    [Route("api/[controller]")]

    [Authorize(Roles = "Admin,POC")]

    public class EmployeeController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            List<Employee> employees =
                new()
                {
                    new Employee
                    {
                        Id = 1,
                        Name = "Neha",
                        Salary = 60000
                    },

                    new Employee
                    {
                        Id = 2,
                        Name = "Rahul",
                        Salary = 50000
                    }
                };

            return Ok(employees);
        }
    }
}