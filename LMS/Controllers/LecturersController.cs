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
    public class LecturersController : ApiController
    {
		ILecturerManager _lManager;
		public LecturersController(ILecturerManager lManager)
		{
			_lManager = lManager;
		}

		// GET: api/Lecturers
		[HttpGet]
		[Route("api/lecturers")]
		public IHttpActionResult Get()
        {
            return Ok(_lManager.GetAllLecturers());
        }

        // GET: api/Lecturers/5
        public IHttpActionResult Get(int id)
        {
			try
			{
				Lecturer lecturer = _lManager.GetLecturerById(id);
				if (lecturer == null)
				{
					return NotFound();
				}
				return Ok(lecturer);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		// POST: api/Lecturers
		[HttpPost]
		[Route("api/lecturer/createlecturer")]
		public IHttpActionResult Post(Lecturer value)
        {
			var lecturer = _lManager.CreateLecturer(value);
			return Ok(lecturer);
        }

		// PUT: api/lecturers/5
		public IHttpActionResult Put(int id, Lecturer value)
		{
			var lecturer = _lManager.UpdateLecturer(id, value);
			return Ok(lecturer);
		}

		// DELETE: api/Lecturers/5
		public IHttpActionResult Delete(int id)
        {
			var lecturer = _lManager.DeletLecturerById(id);
			return Ok(lecturer);
		}
    }
}
