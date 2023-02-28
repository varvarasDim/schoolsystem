using System;
namespace edu_services.Domain
{
    //Added class for the teacher
	public class Teacher
	{
		public Teacher(string firstname, string lastname)
		{
            this.Firstname = firstname;
            this.LastName = lastname;
        }

        public string Firstname { get; set; }
        public string LastName { get; set; }
	}
}

