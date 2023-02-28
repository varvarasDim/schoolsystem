using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using edu_services.Domain;
using edu_services.DTO;
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
        public ActionResult<(String, String)> GetRoster()
        {
            _logger.LogInformation($"Getting the roster for the classroom");

            //Check that the classroom exists
            var classroom = _schoolService.GetClassroom();
            if (classroom == null) 
            {
                return BadRequest("Classroom does not exist");
            }

            try
            {
                //Transform it to the the DTO Roster
                return Ok(new Roster(_schoolService.GetRoster()));
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error while trying to fetch the roster", ex);
                return StatusCode(500);
            }

        }

        //Add teacher in the classroom (Patch because a partial update is occuring)
        [HttpPatch("/classroom/teacher")]
        public ActionResult<Teacher> AddTeacher ([FromBody] Person teacher)
        {
            _logger.LogInformation($"Adding teacher to classroom");

            //Check that the classroom exists
            var classroom = _schoolService.GetClassroom();
            if (classroom == null)
            {
                return BadRequest("Classroom does not exist");
            }

            try
            {
                var teacherAdded = _schoolService.AddTeacherToClassroom(teacher);
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
        public ActionResult<List<Student>> AddStudents( [FromBody] List<Person> students)
        {
            _logger.LogInformation($"Adding students to classroom");

            //Check that the classroom exists
            var classroom = _schoolService.GetClassroom();
            if (classroom == null)
            {
                return BadRequest("Classroom does not exist");
            }

            try
            {
                foreach (var student in students)
                {
                    _schoolService.AddStudentToClassroom(student);
                }

                return Ok(_schoolService.GetClassroom().Students);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error while trying to add students", ex);
                return StatusCode(500);

            }
        }
    }
}
