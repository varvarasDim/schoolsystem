using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using edu_services.DTO;
using edu_services.Request;
using edu_services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace edu_services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly ISchoolService _schoolService;

        public ApiController(ILogger<ApiController> logger, ISchoolService schoolService)
        {
            _logger = logger;
            _schoolService = schoolService;
        }

        //Get the Roster for the specific classroom
        [HttpGet("/classroom/")]
        public ActionResult<ClassroomDto> GetRoster()
        {
            _logger.LogInformation($"Getting the roster for the classroom");

            try
            {
                //Check that the classroom exists
                var classroom = _schoolService.GetClassroom();
                if (classroom == null)
                {
                    return BadRequest("Classroom does not exist");
                }

                return Ok(classroom);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error while trying to fetch the roster", ex);
                return StatusCode(500);
            }

        }

        //Add teacher in the classroom (Patch because a partial update is occuring)
        [HttpPatch("/classroom/teacher")]
        public ActionResult<TeacherDto> AddTeacher ([FromBody] AddTeacher teacher)
        {
            _logger.LogInformation($"Adding teacher to classroom");

            try
            {
                //Check that the classroom exists
                var classroom = _schoolService.GetClassroom();
                if (classroom == null)
                {
                    return BadRequest("Classroom does not exist");
                }

                var teacherDto = new TeacherDto() { Firstname = teacher.Firstname, Lastname = teacher.Lastname };
                var teacherAdded = _schoolService.AddTeacherToClassroom(teacherDto);
                return Ok(teacherAdded);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error while trying to add a teacher", ex);
                return StatusCode(500);
            }
        }

        //Add Students in the classroom (Patch because a partial update is occuring)
        [HttpPatch("/classroom/students")]
        public ActionResult<List<StudentDto>> AddStudents( [FromBody] List<AddStudent> students)
        {
            _logger.LogInformation($"Adding students to classroom");

            try
            {
                //Check that the classroom exists
                var classroomDto = _schoolService.GetClassroom();
                if (classroomDto == null)
                {
                    return BadRequest("Classroom does not exist");
                }

                foreach (var student in students)
                {
                    var studentDto = new StudentDto() { Firstname = student.Firstname, Lastname = student.Lastname};
                    _schoolService.AddStudentToClassroom(studentDto);
                }

                var updatedClassroomDto = _schoolService.GetClassroom();
                return Ok(updatedClassroomDto.Students);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error while trying to add students", ex);
                return StatusCode(500);

            }
        }
    }
}
