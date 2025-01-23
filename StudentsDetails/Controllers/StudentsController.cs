using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Data.Layer;

namespace StudentsDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public readonly IStudentRepository studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        [HttpGet("DisplayStudents")]
        public IActionResult DisplayStudents()
        {
            try
            {
                return Ok(studentRepository.GetStudents());
            }
            catch (Exception ex) 
            {
                 return BadRequest(ex.Message);
            }
        }
    }
}
