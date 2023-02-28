using System;
using System.Collections.Generic;
using edu_services.Domain;

namespace edu_services.DTO
{
    //This class is used for the mapping of the domain to the DTO for the presentation of data to the client 
	public class Roster
	{
        public Roster((Teacher, List<Student>) classroom)
        {
            this.Teacher = classroom.Item1;
            this.Students = classroom.Item2;
        }

        public Roster(Classroom<Teacher, Student> classroom)
        {
            this.Teacher = classroom.Teacher;
            this.Students = classroom.Students;
        }

        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
    }


}

