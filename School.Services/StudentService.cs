using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    public class StudentService
    {
        private readonly Guid _userId;

        public StudentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStudent(StudentCreate model)
        {
            var entity = new Student()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                GradeLevel = model.GradeLevel
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StudentItems> GetAllStudents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Students
                        .Select(
                            e =>
                                new StudentItems
                                {
                                    StudentId = e.Id,
                                    StudentName = e.LastName + e.FirstName,
                                    StudentGrade = e.GradeLevel
                                }
                        );  

                return query.ToArray();
            }

        }
        public StudentItems GetStudentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Students
                        .Single(e => e.Id == id);
              
                //List<string> cList = new List<string>();
                //if (entity.CourseList.Count != 0)
                //{
                //    foreach (Course course in entity.CourseList)
                //    {
                //        cList = cList.Add(course.Name);
                //    }
                //}
  
                return

                    new StudentItems
                    {
                        StudentId = entity.Id,
                        StudentName = entity.LastName + entity.FirstName,
                        StudentGrade = entity.GradeLevel,
                  
 //                     StudentCourses = cList                    

                    };
            }
        }
        public bool UpdateStudent(StudentUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Students
                        .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.GradeLevel = model.GradeLevel;

                return ctx.SaveChanges() == 1;
            }
        }
        public void AddStudentToCourse(int studentId, int courseId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var foundStudent = ctx.Students.Single(s => s.Id == studentId);
                var foundCourse = ctx.Courses.Single(c => c.Id == courseId);
                //foundCourse.StudentList.Add(foundStudent);
                var testing = ctx.SaveChanges();
            }

        }
        public bool DeleteStudent(int studentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Students
                        .Single(e => e.Id == studentId);

                ctx.Students.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
