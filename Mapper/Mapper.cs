using System;
using System.Collections.Generic;
using edu_services.Domain;
using edu_services.DTO;

namespace edu_services.Mapper
{
	public static class Mapper
    {

        public static ClassroomDto TransformClassroomToClassroomDto(Classroom<Teacher, Student> classroom)
        {
            var classroomDto = new ClassroomDto();
            if (classroom.Teacher != null)
                classroomDto.Teacher = new TeacherDto() { Firstname = classroom.Teacher.Firstname, Lastname = classroom.Teacher.LastName };

            if (classroom.Students != null)
            { 
                classroomDto.Students = new List<StudentDto>();
                foreach (var student in classroom.Students)
                {
                    classroomDto.Students.Add(new StudentDto() { Firstname = student.Firstname, Lastname = student.LastName });
                }
            }
            return classroomDto;
        }

        public static StudentDto TransformStudentToStudentDto(Student student)
        {
            if (student != null)
                return new StudentDto() { Firstname = student.Firstname, Lastname = student.LastName };
            else return null;
        }

        public static TeacherDto TransformTeacherToTeacherDto(Teacher teacher)
        {
            if (teacher != null)
                return new TeacherDto() { Firstname = teacher.Firstname, Lastname = teacher.LastName };
            else return null;
        }
    }
}

