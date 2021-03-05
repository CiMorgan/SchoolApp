using Microsoft.AspNet.Identity;
using School.Models;
using School.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolWebApi.Controllers
{
    [Authorize]
    public class TeacherController : ApiController
    {
        public IHttpActionResult Get()
        {
            TeacherService teacherService = CreateTeacherService();
            var teacher = teacherService.GetTeacher();
            return Ok(teacher);
        }
        public IHttpActionResult Post(TeacherCreate teacher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeacherService();

            if (!service.CreateTeacher(teacher))
                return InternalServerError();

            return Ok();
        }
        private TeacherService CreateTeacherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var teacherService = new TeacherService(userId);
            return teacherService;
        }

        public IHttpActionResult Get(int id)
        {
            TeacherService noteService = CreateTeacherService();
            var note = noteService.GetTeacherById(id);
            return Ok(note);
        }

        public IHttpActionResult Put(TeacherEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeacherService();

            if (!service.UpdateTeacher(note))
                return InternalServerError();

            return Ok();
        }
        [HttpPut]
        [Route("api/Teacher/{id}/Course/")]
        public IHttpActionResult AddTeacherToCourse(int id, [FromBody] AddTeacher model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeacherService();

            if (!service.AddTeacherToCourse(id, model))
                return InternalServerError();

            return Ok();
        }
        //[HttpPut]
        //[Route("api/Teacher/{id}/Activity/")]
        //public IHttpActionResult AddTeacherToActivity(int id, [FromBody] AddActivityTeacher model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateTeacherService();

        //    if (!service.AddTeacherToActivity(id, model))
        //        return InternalServerError();

        //    return Ok();
        //}
        public IHttpActionResult Delete(int id)
        {
            var service = CreateTeacherService();

            if (!service.DeleteTeacher(id))
                return InternalServerError();

            return Ok();
        }

    }
}
