using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
	public interface ICourseManager
	{
		Course CreateCourse(Course course);

		List<Course> GetAllCourses();

		Course GetCourseById(int id);

		Course DeleteCourseById(int id);

		Course UpdateCourse(int id, Course value);
	}
}
