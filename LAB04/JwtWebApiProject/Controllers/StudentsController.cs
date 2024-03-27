using WebApi.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static IDictionary<string, Student> students = new Dictionary<string, Student>();   

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students.Values.ToList();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Student student;
            students.TryGetValue(id, out student);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (string.IsNullOrEmpty(student?.ID))
                return BadRequest("Missing ID");
            students[student.ID] = student;
            return Created();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] Student student)
        {
            students[id] = student;
            return Ok();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            students.Remove(id);
            return NoContent();
        }
    }
}
