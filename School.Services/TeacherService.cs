using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    public class TeacherService
    {

        private readonly Guid _userId;

        public TeacherService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeacher(TeacherCreate model)
        {
            var entity =
                new Teacher()
                {
                    TeacherId = model.TeacherId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Department = (Teacher.DepartmentName)model.Department,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teachers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TeacherListItem> GetTeacher()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teachers
                        .Select(
                            e =>
                                new TeacherListItem
                                {
                                    TeacherId = e.TeacherId,
                                    TeacherName = e.LastName + e.FirstName,
                                    Department = (Teacher.DepartmentName)e.Department,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public TeacherDetail GetTeacherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == id);
                return
                    new TeacherDetail
                    {
                        TeacherId = entity.TeacherId,
                        TeacherName = entity.LastName + entity.FirstName,
                        Department = (Teacher.DepartmentName)entity.Department,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public IEnumerable<TeacherListItem> GetAllTeacher()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teachers
                        .Select(
                            e =>
                                new TeacherListItem
                                {
                                    TeacherId = e.TeacherId,
                                    TeacherName = e.LastName + e.FirstName,
                                    Department = (Teacher.DepartmentName)e.Department,
                                }
                        );

                return query.ToArray();
            }

        }

        public bool UpdateTeacher (TeacherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == model.TeacherId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Department = (Teacher.DepartmentName)model.Department;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTeacher(int teacherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == teacherId);

                ctx.Teachers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
