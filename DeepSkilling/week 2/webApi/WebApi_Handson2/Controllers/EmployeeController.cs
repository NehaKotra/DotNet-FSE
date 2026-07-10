using Microsoft.AspNetCore.Mvc;

namespace WebApi_Handson2.Controllers
{
    [ApiController]

    [Route("api/Emp")]

    public class EmployeeController : ControllerBase
    {
        private static List<string> employees =
            new List<string>
            {
                "Neha",
                "Rahul",
                "Priya",
                "Arjun"
            };

        //--------------------------------------------------
        // GET
        //--------------------------------------------------

        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        //--------------------------------------------------
        // GET BY ID
        //--------------------------------------------------

        [HttpGet("{id}")]

        public IActionResult GetEmployee(int id)
        {
            if (id < 0 || id >= employees.Count)
                return BadRequest("Invalid Id");

            return Ok(employees[id]);
        }

        //--------------------------------------------------
        // POST
        //--------------------------------------------------

        [HttpPost]

        public IActionResult AddEmployee([FromBody] string employee)
        {
            employees.Add(employee);

            return Ok("Employee Added Successfully");
        }

        //--------------------------------------------------
        // PUT
        //--------------------------------------------------

        [HttpPut("{id}")]

        public IActionResult UpdateEmployee(int id,
            [FromBody] string employee)
        {
            if (id < 0 || id >= employees.Count)
                return BadRequest("Invalid Id");

            employees[id] = employee;

            return Ok("Employee Updated Successfully");
        }

        //--------------------------------------------------
        // DELETE
        //--------------------------------------------------

        [HttpDelete("{id}")]

        public IActionResult DeleteEmployee(int id)
        {
            if (id < 0 || id >= employees.Count)
                return BadRequest("Invalid Id");

            employees.RemoveAt(id);

            return Ok("Employee Deleted Successfully");
        }
    }
}