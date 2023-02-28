using System;
using System.Collections.Generic;
using edu_services.Domain;
using edu_services.DTO;

namespace edu_services.Services
{
	public interface ISchoolService
	{
		public Classroom<Teacher, Student> GetClassroom();
        public (Teacher, List<Student>) GetRoster();
        public Teacher AddTeacherToClassroom(Person teacher);
        public List<Student> AddStudentToClassroom(Person student);
    }
}

