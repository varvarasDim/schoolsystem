using System;
using System.Collections.Generic;

namespace edu_services.DTO
{
	public class ClassroomDto
	{
		public TeacherDto Teacher { get; set; }
		public List<StudentDto> Students { get; set; }

	}
}

