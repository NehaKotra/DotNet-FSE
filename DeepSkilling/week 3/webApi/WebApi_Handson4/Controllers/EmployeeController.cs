using Microsoft.AspNetCore.Mvc;
using WebApi_Handson4.Models;

namespace WebApi_Handson4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = GetStandardEmployeeList();

        // GET
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        // PUT
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            // Validate Id
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            // Find existing employee
            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Update employee details
            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Permanent = employee.Permanent;
            existingEmployee.Department = employee.Department;
            existingEmployee.Skills = employee.Skills;
            existingEmployee.DateOfBirth = employee.DateOfBirth;

            return Ok(existingEmployee);
        }

        private static List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Neha",
                    Salary = 60000,
                    Permanent = true,
                    Department = new Department
                    {
                        Id = 1,
                        Name = "IT"
                    },
                    Skills = new List<Skill>
                    {
                        new Skill{ Id=1, Name="C#" },
                        new Skill{ Id=2, Name="SQL" }
                    },
                    DateOfBirth = new DateTime(2003,5,20)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Rahul",
                    Salary = 50000,
                    Permanent = false,
                    Department = new Department
                    {
                        Id = 2,
                        Name = "HR"
                    },
                    Skills = new List<Skill>
                    {
                        new Skill{ Id=3, Name="Communication" }
                    },
                    DateOfBirth = new DateTime(2002,3,15)
                }
            };
        }
    }
}