using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RohitEFCoreDemo.Data;
using RohitEFCoreDemo.Models;

namespace RohitEFCoreDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyDBContext _context;

        public StudentController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await Task.FromResult(_context.students.ToList());
            return Ok(students);
        }

        // GET: api/Students/{id}
        [HttpGet]
        public async Task<ActionResult<Student>> GetStudent([FromQuery] int id)
        {
            var student = await Task.FromResult(_context.students.FirstOrDefault(s => s.Id == id));

            if (student == null)
            {
                NoRecordFoundModel noRecordFoundModel = new NoRecordFoundModel();
                noRecordFoundModel.condition = "False";
                noRecordFoundModel.message = "No Record Found.";
                //return NotFound();
                return Ok(noRecordFoundModel);
            }

            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<SubjectModel>> CreateStudent([FromBody]Student student)
        {
            if (student == null)
            {
                return BadRequest("Subject data is null.");
            }

            _context.Add(student);
            await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            NoRecordFoundModel noRecordFoundModel = new NoRecordFoundModel();
            noRecordFoundModel.condition = "True";
            noRecordFoundModel.message = "Student Created Succesfully.";
            //return NotFound();
            return Ok(noRecordFoundModel);
        }
        [HttpPost]
        public async Task<ActionResult<SubjectModel>> CreateStudentsBulk([FromBody] List<Student> students)
        {
            if (students == null)
            {
                return BadRequest("Subject data is null.");
            }

            
            await _context.AddRangeAsync(students);
            await _context.SaveChangesAsync();
            
            

            //return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            NoRecordFoundModel noRecordFoundModel = new NoRecordFoundModel();
            noRecordFoundModel.condition = "True";
            noRecordFoundModel.message = "Student Created Succesfully.";
            //return NotFound();
            return Ok(noRecordFoundModel);
        }
    }
}
