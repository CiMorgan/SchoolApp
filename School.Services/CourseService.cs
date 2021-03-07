using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

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

                //TeacherList = model.TeacherList,
                //StudentList = model.StudentList

            };
            //will have to fix identity models "courses" in class
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<CourseItems> GetAllCourse()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Courses
                        .Select(
                            e =>
                                new CourseItems
                                {
                                    Id = e.Id,
                                    CourseName = e.Name,
                                    CourseDepartment = e.Department.ToString(),
                                    //CourseTeacher = e.TeacherList.ToString(),
                                    //CourseStudent = e.StudentList.ToString(),
                                }

                        );

                return query.ToArray();
            }
        }

        public CourseItemsDetail GetCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var stList = new List<string>();
                var teachList = new List<string>();
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.Id == id);
                foreach (Student student in entity.StudentList)
                {
                    stList.Add(student.LastName);
                }

                foreach (Teacher teacher in entity.TeacherList)
                {
                    teachList.Add(teacher.LastName);
                }

                return
                new CourseItemsDetail
                {
                    Id = entity.Id,
                    CourseName = entity.Name,
                    Department = entity.Department.ToString(),
                    TeacherList = teachList, 
                    StudentList = stList
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
                        .Single(e => e.Id == model.CourseId);

                entity.Id = model.CourseId;
                entity.Name = model.CourseName;
                entity.Department = model.CourseDepartment;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteCourse(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.Id == courseId);

                ctx.Courses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddStudentToCourse(int id, AddStudent model)
        {
            var stList = new AddStudent()
            {
                StudentCourseList = model.StudentCourseList
            };
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.Id == id);
                foreach (int studentId in stList.StudentCourseList)
                {
                    var student = ctx
                        .Students.Single(s => s.Id == studentId);
                    entity.StudentList.Add(student);
                }
                return ctx.SaveChanges() > 0;
            }
        }

        public bool AddTeacherToCourse(int id, AddTeacher model)
        {
            var teachList = new AddTeacher()
            {
                TeacherCourseList = model.TeacherCourseList
            };
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.Id == id);
                foreach (int teacherId in teachList.TeacherCourseList)
                {
                    var teacher = ctx
                        .Teachers.Single(t => t.TeacherId == teacherId);
                    entity.TeacherList.Add(teacher);
                }
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
