using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    public class DisciplineService
    {
        private readonly Guid _userId;

        public DisciplineService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDiscipline(DisciplineCreate model)
        {
            var entity =
                new Discipline()
                {
                    DisciplineId = model.DisciplineId,
                    DisciplineType = (Discipline.TypeOfDiscipline)model.DisciplineType,
                    Comment = model.Comment,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Disciplines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DisciplineListItem> GetDiscipline()
         {
             using (var ctx = new ApplicationDbContext())
             {
                 var query = 
                     ctx
                         .Disciplines
                         .Select(
                             e =>
                                 new DisciplineListItem
                                 {
                                     DisciplineId = e.DisciplineId,
                                     //DisciplineType = (DisciplineListItem.Discipline)e.DisciplineType,
                                     Comment = e.Comment,
                                     CreatedUtc = e.CreatedUtc,
                                     ModifiedUtc = e.ModifiedUtc,
                                 }
                         );

                 return query.ToArray();
             }
         }
        public DisciplineDetail GetDisciplineById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Disciplines
                        .Single(e => e.DisciplineId == id);
                return
                    new DisciplineDetail
                    {
                        DisciplineId = entity.DisciplineId,
                        //DisciplineType = (DisciplineDetail.TypeOfDiscipline)entity.DisciplineType,
                        Comment = entity.Comment,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public IEnumerable<DisciplineListItem> GetAllDiscipline()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Disciplines
                        .Select(
                            e =>
                                new DisciplineListItem
                                {
                                    DisciplineId = e.DisciplineId,
                                    //DisciplineType = (DisciplineListItem.TypeOfDiscipline)e.DisciplineType,
                                    Comment = e.Comment,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc,
                                }
                        );

                return query.ToArray();
            }

        }
        public bool UpdateDiscipline(DisciplineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Disciplines
                        .Single(e => e.DisciplineId == model.DisciplineId);

                entity.DisciplineType = (Discipline.TypeOfDiscipline)model.DisciplineType;
                entity.Comment = model.Comment;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteDiscipline(int disciplineId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Disciplines
                        .Single(e => e.DisciplineId == disciplineId);

                ctx.Disciplines.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
