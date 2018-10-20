using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
	public interface ILecturerManager
	{
		Lecturer CreateLecturer(Lecturer lecturer);

		List<Lecturer> GetAllLecturers();

		Lecturer GetLecturerById(int id);

		Lecturer DeletLecturerById(int id);

		Lecturer UpdateLecturer(int id, Lecturer value);
	}
}
