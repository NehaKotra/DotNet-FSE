using Microsoft.AspNetCore.Mvc;

namespace WebApi_Handson1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<string> values =
            new List<string>
            {
                "Value1",
                "Value2",
                "Value3"
            };

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(values);
        }

        // GET api/values/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return BadRequest("Invalid Id");

            return Ok(values[id]);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            values.Add(value);

            return Ok("Value Added Successfully");
        }

        // PUT api/values/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
                return BadRequest("Invalid Id");

            values[id] = value;

            return Ok("Value Updated Successfully");
        }

        // DELETE api/values/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return BadRequest("Invalid Id");

            values.RemoveAt(id);

            return Ok("Value Deleted Successfully");
        }
    }
}