using Microsoft.AspNet.Identity;
using School.Data;
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
    public class DisciplineController : ApiController
    {
        public IHttpActionResult Get()
        {
            DisciplineService DisciplineService = CreateDisciplineService();
            var discipline = DisciplineService.GetDiscipline();
            return Ok(discipline);
        }
        public IHttpActionResult Post(DisciplineCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDisciplineService();

            if (!service.CreateDiscipline(note))
                return InternalServerError();

            return Ok();
        }
        private DisciplineService CreateDisciplineService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var disciplineService = new DisciplineService(userId);
            return disciplineService;
        }

        public IHttpActionResult Get(int id)
        {
            DisciplineService disciplineService = CreateDisciplineService();
            var discipline = disciplineService.GetDisciplineById(id);
            return Ok(discipline);
        }

        public IHttpActionResult Put(DisciplineEdit Discipline)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDisciplineService();

            if (!service.UpdateDiscipline(Discipline))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateDisciplineService();

            if (!service.DeleteDiscipline(id))
                return InternalServerError();

            return Ok();
        }

    }
}
