using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Data.Teacher;

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
                    Department = model.Department,
                    CreatedUtc = DateTimeOffset.Now
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
                                    TeacherName = e.LastName + ", " + e.FirstName,
                                    Department = e.Department.ToString(),
                                }
                        );

                return query.ToArray();
            }
        }
        public TeacherDetail GetTeacherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var teacherCourseList = new List<string>();
                var teacherActivityList = new List<string>();
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == id);
                foreach (Course course in entity.CourseList)
                {
                    teacherCourseList.Add(course.Name);
                }

                foreach (Activity activity in entity.ActivityList)
                {
                    teacherActivityList.Add(activity.Name.ToString());
                }
                return
                    new TeacherDetail
                    {
                        TeacherId = entity.TeacherId,
                        TeacherName = entity.LastName + ", " + entity.FirstName,
                        Department = Enum.GetName(typeof(DepartmentName), entity.Department),
                        TeacherActivity = teacherActivityList,
                        TeacherCourse = teacherCourseList
                    };
            }
        }
        public bool UpdateTeacher(TeacherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == model.TeacherId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Department = model.Department;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                foreach (var courseId in model.ListOfCourses)
                {
                    var course = ctx
                        .Courses.Single(s => s.Id == courseId);
                    entity.CourseList.Add(course);
                }
                foreach (var activityId in model.ActivityLead)
                {
                    var activity = ctx
                        .Activities.Single(s => s.Id == activityId);
                    entity.ActivityList.Add(activity);
                }
                return ctx.SaveChanges() > 0;
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
        //public bool AddTeacherToCourse(int id, AddTeacher model)
        //{
        //    var teacherList = new AddTeacher()
        //    {
        //        TeacherCourseList = model.TeacherCourseList
        //    };
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Teachers
        //                .Single(e => e.TeacherId == id);
        //        foreach (int courseId in teacherList.TeacherCourseList)
        //        {
        //            var course = ctx
        //                .Courses.Single(s => s.Id == courseId);
        //            entity.CourseList.Add(course);
        //        }
        //        return ctx.SaveChanges() > 0;
        //    }
        //}
        //public bool AddTeacherToActivity(int id, AddTeacher model)
        //{
        //    var activityList = new AddTeacher()
        //    {
        //        TeacherActivityList = model.TeacherActivityList
        //    };
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Activities
        //                .Single(e => e.Id == id);
        //        foreach (int activityId in activityList.TeacherActivityList)
        //        {
        //            var activity = ctx
        //                .Activities.Single(s => s.Id == activityId);
        //            entity.TeacherList.Add(teacher);
        //        }
        //        return ctx.SaveChanges() > 0;
        //    }
    }
}

