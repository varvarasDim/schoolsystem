using System;
using System.Collections.Generic;
using edu_services.Domain;
using edu_services.DTO;

namespace edu_services.Services
{
	public interface ISchoolService
	{
		public ClassroomDto GetClassroom();
        public TeacherDto AddTeacherToClassroom(TeacherDto teacher);
        public List<StudentDto> AddStudentToClassroom(StudentDto student);
    }
}

