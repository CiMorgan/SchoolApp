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
                                    Department = Enum.GetName(typeof(DepartmentName), e.Department)
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
                var EC =
                    ctx.Activities.Single(f => f.TeacherId == id);
 
                    teacherActivityList.Add(EC.Name.ToString());
  
                return
                    new TeacherDetail
                    {
                        TeacherId = entity.TeacherId,
                        TeacherName = entity.LastName + entity.FirstName,
                        Department = Enum.GetName(typeof(DepartmentName), entity.Department),
                        TeacherCourseList = teacherCourseList,
                        TeacherActivityList = teacherActivityList
                    };
            }
        }
        public IEnumerable<TeacherListItem> GetAllTeachers()
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
                                    Department = Enum.GetName(typeof(DepartmentName), e.Department),
                                }
                        );

                return query.ToArray();
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
        public bool AddTeacherToCourse(int id, AddTeacher model)
        {
            var courseList = new AddTeacher()
            {
                TeacherCourseList = model.TeacherCourseList
            };
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.Id == id);
                foreach (int teacherId in courseList.TeacherCourseList)
                {
                    var teacher = ctx
                        .Teachers.Single(s => s.TeacherId == teacherId);
                    entity.TeacherList.Add(teacher);
                }
                return ctx.SaveChanges() > 0;
            }
        }
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

