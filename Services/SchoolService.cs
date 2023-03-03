using System;
using System.Collections.Generic;
using System.Linq;
using edu_services.Domain;
using edu_services.DTO;
using edu_services.Mapper;

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
        public List<StudentDto> AddStudentToClassroom(StudentDto student)
        {
            _classroom.AddStudent(new Student(student.Firstname, student.Lastname));

            List<StudentDto> studentDto = new List<StudentDto>();
            foreach(var st in _classroom.Students)
                studentDto.Add(Mapper.Mapper.TransformStudentToStudentDto(st));

            return studentDto;
        }

        //Method for adding the teacher to the classroom
        public TeacherDto AddTeacherToClassroom(TeacherDto teacher)
        {
            _classroom.AddTeacher(new Teacher(teacher.Firstname, teacher.Lastname));
            return Mapper.Mapper.TransformTeacherToTeacherDto(_classroom.Teacher);
        }

        //This is for intenal usage to check if the classroom exists
        public ClassroomDto GetClassroom()
        {
            return Mapper.Mapper.TransformClassroomToClassroomDto(_classroom);
        }
    }
}

