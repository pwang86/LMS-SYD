using BL.Managers.Interfaces;
using Data.Repositories.Interfaces;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
	public class LecturerManager : ILecturerManager
	{
		private ILecturerRepository _lecturerRepository;

		public LecturerManager(ILecturerRepository lecturerRepository)
		{
			_lecturerRepository = lecturerRepository;
		}
		public Lecturer CreateLecturer(Lecturer lecturer1)
		{
			var lecturer = new Lecturer()

			{   Name = lecturer1.Name,
				StaffNumber = lecturer1.StaffNumber,
				Email = lecturer1.Email,
				Bibliography = lecturer1.Bibliography,
			};
			if (!_lecturerRepository.Records.Any(x => x.Email == lecturer.Email))
			{
				//student.Id = _studentRepository.Records.Count() + 1;
				_lecturerRepository.Add(lecturer);
			}
			else
			{
				return _lecturerRepository.Records.Where(x => x.Email == lecturer.Email).FirstOrDefault();
			}

			return lecturer;
		}

		public Lecturer DeletLecturerById(int id)
		{
			var lecturer = _lecturerRepository.Records.Where(x => x.Id == id).FirstOrDefault();
			if (lecturer != null)
			{
				_lecturerRepository.Delete(lecturer);
			}
			return lecturer;
		}

		public List<Lecturer> GetAllLecturers()
		{
			return _lecturerRepository.GetAll().ToList();
		}

		public Lecturer GetLecturerById(int id)
		{
			var lecturer = _lecturerRepository.Records.Where(x => x.Id == id).FirstOrDefault();
			if (lecturer != null)
			{
				return _lecturerRepository.GetById(id);
			}
			else
				return null;
		}

		public Lecturer UpdateLecturer(int id, Lecturer value)
		{
			var lecturer = _lecturerRepository.Records.Where(x => x.Id == id).FirstOrDefault();
			if (lecturer != null)
			{
				lecturer.Name = value.Name;
				lecturer.StaffNumber = value.StaffNumber;
				lecturer.Email = value.Email;
				lecturer.Bibliography = value.Bibliography;
				_lecturerRepository.Update(lecturer);
				return lecturer;
			}
			else
				return null;
		}
	}
}
