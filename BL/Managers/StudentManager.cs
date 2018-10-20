using AutoMapper;
using BL.Managers.Interfaces;
using BL.Util;
using Data.Repositories.Interfaces;
using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
	public class StudentManager : IStudentManager
	{
		private IStudentRepository _studentRepository;

		public StudentManager(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		public Student CreateStudent(Student student1)
		{
			var student = new Student()
			{
				FirstName = student1.FirstName,
				LastName = student1.LastName,
				Gender = student1.Gender,
				DateOfBirth = student1.DateOfBirth,
				Email = student1.Email,
				Credit = student1.Credit
			};

			//if (!_studentRepository.Records.Any(x => x.Email == "test@test123.com"))
			
			if (!_studentRepository.Records.Any(x => x.Email == student.Email))
			{
				//student.Id = _studentRepository.Records.Count() + 1;
				_studentRepository.Add(student);
			}
			else
			{
				return _studentRepository.Records.Where(x => x.Email == student.Email).FirstOrDefault();
			}

			return student;
		}

		public List<Student> GetAllStudents()
		{
			return _studentRepository.GetAll().ToList();
		}

		public StudentDto GetStudentById(int id)
		{
			return Mapper.Map<Student, StudentDto>(_studentRepository.GetById(id));
		}

		public Student UpdateStudent(int id, Student value)
		{
			var student = _studentRepository.Records.Where(x => x.Id == id).FirstOrDefault();
			if (student != null)
			{
				student.FirstName = value.FirstName;
				student.LastName = value.LastName;
				student.Gender = value.Gender;
				student.DateOfBirth = value.DateOfBirth;
				student.Email = value.Email;
				student.Credit = value.Credit;
				_studentRepository.Update(student);
			}
			return student;
		}

		public Student DeleteStudentById(int id)
		{
			var student = _studentRepository.Records.Where(x => x.Id == id).FirstOrDefault();
			if (student != null)
			{
				_studentRepository.Delete(student);
			}
			return student;
		}
		
		public List<Student> SearchStudentByName(string name)
		{
			return _studentRepository.Records.Where(x => x.FirstName.Contains(name)).ToList();
		}

		public StudentSearchDto SearchStudent(SearchAttribute search)
		{
			if (search.PageNumber == 0)
			{
				search.PageNumber = 1;
			}
			if (search.PageSize == 0)
			{
				search.PageSize = 10;
			}
			var students = _studentRepository.Records.Search(search.SearchValue);
			students = students.ApplySort(search.SortString, search.SortOrder);

			var SearchResult = new StudentSearchDto
			{
				PageSize = search.PageSize,
				TotalPage = students.Count() / search.PageSize + (students.Count() % search.PageSize == 0 ? 0 : 1)
			};

			SearchResult.PageNumber = search.PageNumber > SearchResult.TotalPage ? 1 : search.PageNumber;

			SearchResult.Students = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(students.Skip((SearchResult.PageNumber - 1) * SearchResult.PageSize).Take(SearchResult.PageSize));
			return SearchResult;
		}


	}
}
