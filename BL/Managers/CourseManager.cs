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
	public class CourseManager : ICourseManager
	{
		private ICourseRepository _courseRepository;

		public CourseManager(ICourseRepository courseRepository)
		{
			_courseRepository = courseRepository;
		}

		public Course CreateCourse(Course course1)
		{
			var course = new Course()
			{
				Title = course1.Title,
				Description = course1.Description,
				Fee = course1.Fee,
				MaxStudent = course1.MaxStudent,
				Language = course1.Language
			};
			if (!_courseRepository.Records.Any(x => x.Title == course.Title))
			{
				//student.Id = _studentRepository.Records.Count() + 1;
				_courseRepository.Add(course);
			}
			else
			{
				return _courseRepository.Records.Where(x => x.Title == course.Title).FirstOrDefault();
}

			return course;
		}

		public Course DeleteCourseById(int id)
		{
			var course = _courseRepository.Records.Where(x => x.Id == id).FirstOrDefault();
			if (course != null)
			{
				_courseRepository.Delete(course);
			}
			return course;
		}

		public List<Course> GetAllCourses()
		{
			return _courseRepository.GetAll().ToList();
		}

		public Course GetCourseById(int id)
		{
			var course = _courseRepository.Records.Where(x => x.Id == id).FirstOrDefault();
			if (course != null)
			{
				return _courseRepository.GetById(id);
			}
			else
				return null;
		}

		public Course UpdateCourse(int id, Course value)
		{
			var course = _courseRepository.Records.Where(x => x.Id == id).FirstOrDefault();
			if (course != null)
			{
				course.Title = value.Title;
				course.Description = value.Description;
				course.Fee = value.Fee;
				course.MaxStudent = value.MaxStudent;
				course.Language = value.Language;
				_courseRepository.Update(course);
				return course;
			}
			else
				return null;
		}
	}
}
