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
    public class CourseController : ApiController
    {
        private CourseService CreateCourseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var courseService = new CourseService(userId);
            return courseService;
        }

        public IHttpActionResult Get()
        {
            CourseService courseService = CreateCourseService();
            var courses = courseService.GetAllCourse();
            return Ok(courses);
        }

        public IHttpActionResult Post(CourseCreate course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCourseService();

            if (!service.CreateCourse(course))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            CourseService courseService = CreateCourseService();
            var note = courseService.GetCourseById(id);
            return Ok(note);
        }

        public IHttpActionResult Put(CourseUpdate course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCourseService();

            if (!service.UpdateCourse(course))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCourseService();

            if (!service.DeleteCourse(id))
                return InternalServerError();

            return Ok();
        }
    }
}
