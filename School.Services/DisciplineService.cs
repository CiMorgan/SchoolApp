using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Data.Discipline;

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
                    StudentId = model.StudentId,
                    DisciplineType = model.DisciplineType,
                    Expelled = model.Expelled,
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
                        //.AsEnumerable()
                        .Select(
                            e =>
                                new DisciplineListItem
                                {
                                    StudentName = (e.Student.FirstName + " " + e.Student.LastName),
                                    DisciplineId = e.DisciplineId,
                                    DisciplineType = e.DisciplineType.ToString() ,
                                    Expelled = e.Expelled,
                                    Comment = e.Comment,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );

                return query.ToArray();
            }
         }
        public DisciplineDetail GetDisciplineById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var disciplineStudentList = new List<string>();
                var entity =
                    ctx
                        .Disciplines
                        .Single(e => e.DisciplineId == id);
                foreach (Student student in entity.StudentList)
                {
                    disciplineStudentList.Add(student.FirstName + " " + student.LastName);
                }
                return
                    new DisciplineDetail
                    {
                        StudentName = (entity.Student.FirstName + " " + entity.Student.LastName),
                        DisciplineId = entity.DisciplineId,
                        DisciplineType = Enum.GetName(typeof(TypeOfDiscipline), entity.DisciplineType),
                        Expelled = entity.Expelled,
                        Comment = entity.Comment,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
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

                entity.DisciplineType = model.DisciplineType;
                entity.Comment = model.Comment;
                entity.Expelled = model.Expelled;
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
        public bool AddDisciplineToStudent(int id, AddDiscipline model)
        {
            var disciplineList = new AddDiscipline()
            {
                StudentDisciplineList = model.StudentDisciplineList
            };
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Disciplines
                        .Single(e => e.DisciplineId == id);
                foreach (int disciplineId in disciplineList.StudentDisciplineList)
                {
                    var student = ctx
                        .Students.Single(s => s.Id == disciplineId);
                    entity.StudentList.Add(student);
                }
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
