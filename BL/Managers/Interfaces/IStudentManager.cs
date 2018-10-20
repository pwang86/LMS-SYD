using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
	public interface IStudentManager
	{
		Student CreateStudent(Student student);

		List<Student> GetAllStudents();

		StudentDto GetStudentById(int id);

		Student UpdateStudent(int id, Student value);

		Student DeleteStudentById(int id);

		List<Student> SearchStudentByName(string name);

		StudentSearchDto SearchStudent(SearchAttribute search);

	}

}
