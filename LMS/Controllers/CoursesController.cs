using BL.Managers.Interfaces;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    public class CoursesController : ApiController
    {
		ICourseManager _cManager;
		public CoursesController(ICourseManager cManager)
		{
			_cManager = cManager;
		}

		// GET: api/Courses
		[HttpGet]
		[Route("api/courses")]
		public IHttpActionResult Get()
        {
            return Ok(_cManager.GetAllCourses());
        }

        // GET: api/Courses/5
        public IHttpActionResult Get(int id)
        {
			try
			{
				Course course = _cManager.GetCourseById(id);
				if (course == null)
				{
					return NotFound();
				}
				return Ok(course);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		// POST: api/Courses
		[HttpPost]
		[Route("api/courses/createcourse")]
		public IHttpActionResult Post(Course value)
        {
			var course = _cManager.CreateCourse(value);
			return Ok(course);
        }

		// PUT: api/courses/5
		public IHttpActionResult Put(int id, Course value)
		{
			var course = _cManager.UpdateCourse(id, value);
			return Ok(course);
		}

		// DELETE: api/Courses/5
		public IHttpActionResult Delete(int id)
        {
			var course = _cManager.DeleteCourseById(id);
			return Ok(course);
		}
    }
}
