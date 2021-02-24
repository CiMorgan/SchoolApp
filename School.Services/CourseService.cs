using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    public class CourseService
    {
        private readonly Guid _userId;

        public CourseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCourse(CourseCreate model)
        {
            var entity = new Course()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Department = model.Department,
                    TeacherList = model.TeacherList,
                    StudentList = model.StudentList,
                    
                };
            //will have to fix identity models "courses" in class
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CourseUpdate> GetAllCourse()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Courses
                        .Select(
                            e =>
                                new CourseUpdate
                                {
                                    CourseId = e.Id,
                                    CourseName = e.Name,
                                    CourseDepartment = e.Department,
                                }
                        );

                return query.ToArray();
            }
        }

        public CourseUpdate GetCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == id);
                return
                    new CourseCreate
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Department = entity.Department,
                        TeacherList = entity.TeacherList,
                        StudentList = entity.StudentList,
                        
                    };
            }
        }

        public bool UpdateCourse(CourseUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == model.CourseId );

                entity.Id = model.CourseId;
                entity.Name = model.CourseName;
                entity.Department = model.CourseDepartment;

                return ctx.SaveChanges() == 1;

            }

        }

        public bool DeleteCourse(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == courseId);

                ctx.Courses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
