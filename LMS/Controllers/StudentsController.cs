using BL.Managers.Interfaces;
using BL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model.Dto;
using Model.Model;

namespace LMS.Controllers
{
    public class StudentsController : ApiController
    {
		IStudentManager _stdManager;
		public StudentsController(IStudentManager studentManager) {
			_stdManager = studentManager;
		}

		// GET: api/Students
		[HttpGet]
		[Route("api/students")]
		public IHttpActionResult Get()
		{
			return Ok(_stdManager.GetAllStudents());
		}

		// GET: api/Students/5
		public IHttpActionResult Get(int id)
        {
			try
			{
				StudentDto student = _stdManager.GetStudentById(id);
				if (student == null)
				{
					return NotFound();
				}
				return Ok(student);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
        }

		// POST: api/Students
		[HttpPost]
		[Route("api/test/createstudent")]
		public IHttpActionResult Post(Student value)
        {
			var student = _stdManager.CreateStudent(value);
			return Ok(student);
		}

        // PUT: api/Students/5
        public IHttpActionResult Put(int id, Student value)
        {
			Student student = _stdManager.UpdateStudent(id, value);
			return Ok(student);					
        }

        // DELETE: api/Students/5
        public IHttpActionResult Delete(int id)
        {
			Student student = _stdManager.DeleteStudentById(id);
			return Ok(student);
        }

		[HttpGet]
		[Route("api/students/searchstudentbyname")]
		public IHttpActionResult SearchStudentByName(string value)
		{
			return Ok(_stdManager.SearchStudentByName(value));
		}

		/// <summary>
		/// Advanced Get
		/// </summary>
		/// <param name="sortString"></param>
		/// <param name="sortOrder"></param>
		/// <param name="searchValue"></param>
		/// <param name="pageSize"></param>
		/// <param name="pageNumber"></param>
		/// <returns></returns>
		public IHttpActionResult Get(string sortString = "id", string sortOrder = "asc", string searchValue = "", int pageSize = 10, int pageNumber = 1) {
			SearchAttribute search = new SearchAttribute() {
				SearchValue = searchValue,
				SortOrder = sortOrder,
				SortString = sortString,
				PageNumber = pageNumber,
				PageSize = pageSize
			};
			StudentSearchDto students = _stdManager.SearchStudent(search);
			return Ok(students);
		}
	}
}
