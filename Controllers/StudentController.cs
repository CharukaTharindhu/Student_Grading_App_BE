using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentGradingAPI.Data;
using StudentGradingAPI.Models;

namespace StudentGradingAPI.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class StudentController : Controller
    {
        private readonly StudentAPIDbContext dbContext;

        public StudentController(StudentAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await dbContext.Students.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);

        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentRequest addStudentRequest)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.Name,
                Gender = addStudentRequest.Gender,
                BOD = addStudentRequest.BOD,
                Subject = addStudentRequest.Subject,
                Mark = addStudentRequest.Mark,
                Grade = addStudentRequest.Grade,
                Remark = addStudentRequest.Remark
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, UpdateStudentRequest updateStudentRequest)
        {
            var student = await dbContext.Students.FindAsync(id);

            if(student != null)
            {

                student.Name = updateStudentRequest.Name;
                student.Gender = updateStudentRequest.Gender;
                student.BOD = updateStudentRequest.BOD;
                student.Subject = updateStudentRequest.Subject;
                student.Mark = updateStudentRequest.Mark;
                student.Grade = updateStudentRequest.Grade;
                student.Remark = updateStudentRequest.Remark;

                await dbContext.SaveChangesAsync();

                return Ok(student);
            };

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student != null)
            {
                dbContext.Remove(student);
                await dbContext.SaveChangesAsync();

                return Ok(student);
            }

            return NotFound();

        }

    }
}
