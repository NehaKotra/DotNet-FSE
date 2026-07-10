using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Handson3.Filters;
using WebApi_Handson3.Models;

namespace WebApi_Handson3.Controllers
{
    [ApiController]

    [Route("api/[controller]")]

    [ServiceFilter(typeof(CustomAuthFilter))]

    public class EmployeeController : ControllerBase
    {
        [AllowAnonymous]

        [HttpGet]

        [ProducesResponseType(typeof(List<Employee>),200)]

        [ProducesResponseType(500)]

        public ActionResult<List<Employee>> Get()
        {
            return GetStandardEmployeeList();
        }

        [HttpPost]

        public IActionResult Post([FromBody] Employee employee)
        {
            return Ok(employee);
        }

        [HttpPut]

        public IActionResult Put([FromBody] Employee employee)
        {
            return Ok(employee);
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Name="Neha",
                    Salary=60000,
                    Permanent=true,

                    Department=new Department
                    {
                        Id=1,
                        Name="IT"
                    },

                    Skills=new List<Skill>
                    {
                        new Skill{Id=1,Name="C#"},
                        new Skill{Id=2,Name="SQL"}
                    },

                    DateOfBirth=new DateTime(2003,5,20)
                },

                new Employee
                {
                    Id=2,
                    Name="Rahul",
                    Salary=55000,
                    Permanent=false,

                    Department=new Department
                    {
                        Id=2,
                        Name="HR"
                    },

                    Skills=new List<Skill>
                    {
                        new Skill{Id=3,Name="Communication"}
                    },

                    DateOfBirth=new DateTime(2001,8,15)
                }
            };
        }
    }
}