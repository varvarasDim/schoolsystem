using System;
using System.Collections.Generic;
using System.Linq;
using edu_services.Domain;
using edu_services.DTO;

namespace edu_services.Services
{
    //Service layer that has access to the DataLayer
	public class SchoolService : ISchoolService
	{
        private Classroom<Teacher, Student> _classroom;
        public SchoolService(Classroom<Teacher, Student> classroom)
		{
            _classroom = classroom;
		}

        //Method for adding the student to the classroom
        public List<Student> AddStudentToClassroom(Person student)
        {
            _classroom.AddStudent(new Student(student.Firstname, student.Lastname));
            return _classroom.Students;
        }

        //Method for adding the teacher to the classroom
        public Teacher AddTeacherToClassroom(Person teacher)
        {
            _classroom.AddTeacher(new Teacher(teacher.Firstname, teacher.Lastname));
            return _classroom.Teacher;
        }

        //This is for intenal usage to check if the classroom exists
        public Classroom<Teacher, Student> GetClassroom()
        {
            return _classroom;
        }

        //Returns the roster of the classroom
        public (Teacher, List<Student>) GetRoster()
        {
            return _classroom.GetRoster();
        }
    }
}

