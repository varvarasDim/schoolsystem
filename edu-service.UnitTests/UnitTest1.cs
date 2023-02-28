using System;
using edu_services.Domain;
using Xunit;

namespace edu_service.UnitTests
{
    public class UnitTests
    {
        [Fact]
        public void WhenThereIsNoTeacher_ThrowException()
        {
            var _classroom = new Classroom<Teacher, Student>();
            _classroom.AddStudent(new Student("Student1", "Student1"));
            _classroom.AddStudent(new Student("Student2", "Student2"));
            _classroom.AddStudent(new Student("Student3", "Student3"));

            Assert.Throws<Exception>(() => _classroom.GetRoster());

        }
        [Fact]
        public void WhenThereIsLessThan3Student_ThrowException()
        {

            var _classroom = new Classroom<Teacher, Student>();
            _classroom.AddTeacher(new Teacher("Teacher1", "Teacher1"));
            _classroom.AddStudent(new Student("Student1", "Student1"));
            _classroom.AddStudent(new Student("Student2", "Student2"));

            Assert.Throws<Exception>(() => _classroom.GetRoster());

        }
        [Fact]
        public void WhenTeacherExistsAndStudentsAreMoreThan3_ReturnRoster()
        {
            var _classroom = new Classroom<Teacher, Student>();
            _classroom.AddTeacher(new Teacher("Teacher1", "Teacher1"));
            _classroom.AddStudent(new Student("Student1", "Student1"));
            _classroom.AddStudent(new Student("Student2", "Student2"));
            _classroom.AddStudent(new Student("Student3", "Student3"));

            var result = _classroom.GetRoster();
            Assert.NotNull(result.Item1);
            Assert.NotNull(result.Item2);
        }
    }
}

