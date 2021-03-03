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
    public class StudentController : ApiController
    {
        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var StudentService = new StudentService(userId);
            return StudentService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            StudentService studentService = CreateStudentService();
            var students = studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            StudentService studentService = CreateStudentService();
            var student = studentService.GetStudentById(id);
            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Post(StudentCreate student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStudentService();

            if (!service.CreateStudent(student))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(StudentUpdate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStudentService();

            if (!service.UpdateStudent(model))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateStudentService();

            if (!service.DeleteStudent(id))
                return InternalServerError();

            return Ok();
        }
    }
}
