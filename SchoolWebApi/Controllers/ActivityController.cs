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
    public class ActivityController : ApiController
    {



        private ActivityService CreateActivityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var activityService = new ActivityService(userId);
            return activityService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            ActivityService activityService = CreateActivityService();
            var activities = activityService.GetAllActivity();
            return Ok(activities);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ActivityService activityService = CreateActivityService();
            var activities = activityService.GetActivityById(id);
            return Ok(activities);
        }


        public IHttpActionResult Post(ActivityCreate activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActivityService();

            if (!service.CreateActivity(activity))
                return InternalServerError();

            return Ok("Activity has been added.");
        }

        //public IHttpActionResult Get(int id)
        //{
        //    ActivityService activityService = CreateActivityService();
        //    var note = activityService.GetActivityById(id);
        //    return Ok(note);
        //}

        [HttpPut]
        public IHttpActionResult Put(ActivityUpdate activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActivityService();

            if (!service.UpdateActivity(activity))
                return InternalServerError();

            return Ok("Activity has been updated.");
        }



        [HttpPut]
        [Route("api/Activity/{id}/Student")]
        public IHttpActionResult AddStudentToActivity(int id, [FromBody] AddStudent model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActivityService();

            if (!service.AddStudentToActivity(id, model)) 
                return InternalServerError();

            return Ok("Student has been added to activity.");
        }

        [HttpPut]
        [Route("api/Activity/{id}/Teacher")]
        public IHttpActionResult AddTeacherToActivity(int id, [FromBody] AddTeacher model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActivityService();

            if (!service.AddTeacherToActivity(id, model))
                return InternalServerError();

            return Ok("Teacher has been added to activity.");
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateActivityService();

            if (!service.DeleteActivity(id))
                return InternalServerError();

            return Ok("Activity has been removed.");
        }
    }
}
