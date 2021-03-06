using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Data.Activity;

namespace School.Services
{
    public class ActivityService
    {
        private readonly Guid _userId;

        public ActivityService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateActivity(ActivityCreate model)
        {
            var entity = new Activity()
            {
                Id = model.Id,
                Name = model.Name,
                Duration = model.Duration,
                TeacherId = model.TeacherId,
                LeadTeacher = model.LeadTeacher,
                StudentList = model.StudentList,

            };
            //will have to fix identity models "Activity" in class
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Activities.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<ActivityItems> GetAllActivity()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Activities
                        .Select(
                            e =>
                                new ActivityItems
                                {
                                    Id = e.Id,
                                    ActivityName = e.Name.ToString(),
                                    Duration = e.Duration.ToString()
                                }
                        );
                return query.ToArray();
            }
        }

        public ActivityItemsDetail GetActivityById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var stList = new List<string>();

                var entity =
                    ctx
                        .Activities
                        .Single(e => e.Id == id);

                if (entity.StudentList.Count != 0)
                {
                    foreach (Student student in entity.StudentList)
                    {
                        stList.Add(student.LastName);
                    }
                }
                else
                {
                    string NoStudent = "No student in activity";
                    stList.Add(NoStudent);
                }
                return
                new ActivityItemsDetail
                {
                    Id = entity.Id,
                    ActivityName = entity.Name.ToString(),
                    LeadTeacher = entity.LeadTeacher.LastName,
                    Duration = entity.Duration.ToString(),
                    StudentList = stList
                };
            }
        }

        public bool UpdateActivity(ActivityUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single(e => e.Id == model.ActivityId);

                entity.Id = model.ActivityId;
                entity.Name = model.ActivityName;
                entity.Duration = model.ActivityDuration;
                entity.TeacherId = model.ActivityTeacherId;
                return ctx.SaveChanges() > 0;
            }
        }

        //public ActivityUpdate GetActivityById(int id)
        //{
        //    using (var ctx = new ApplicationDbContext()) 
        //    {
        //        var entity =
        //            ctx
        //                .Activities
        //                .Single(e => e.Id == id);
        //        return
        //            new ActivityUpdate
        //            {
        //                ActivityId = entity.Id,
        //                ActivityName = entity.Name,
        //                ActivityDuration = entity.Duration,
        //                ActivityTeacherId = entity.TeacherId,
        //                ActivityLeadTeacher = entity.LeadTeacher,
        //                ActivityStudentList = entity.StudentList

        //            };
        //    }
        //}

        //public bool UpdateActivity(ActivityUpdate model)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var stList = new List<string>();
        //        var entity =
        //            ctx
        //                .Activities
        //                .Single(e => e.Id == model.ActivityId);

        //                    entity.Id = model.ActivityId,
        //                    entity.Name = model.ActivityName,
        //                    entity.Duration = model.ActivityDuration,
                            

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

        public bool DeleteActivity(int activityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single(e => e.Id == activityId);

                ctx.Activities.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddStudentToActivity(int id, AddStudent model)
        {
            var stList = new AddStudent()
            {
                StudentActivityList = model.StudentActivityList
            };
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single(e => e.Id == id);
                foreach (int studentId in stList.StudentActivityList)
                {
                    var student = ctx
                        .Students.Single(s => s.Id == studentId);
                    entity.StudentList.Add(student);
                }
                return ctx.SaveChanges() > 0;
            }
        }
        public bool AddTeacherToActivity(int id, AddTeacher model)
        {
            var teachList = new AddTeacher()
            {
                TeacherActivityList = model.TeacherActivityList
            };
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single(e => e.Id == id);
                foreach (int Id in teachList.TeacherActivityList)
                {
                    var teacher = ctx
                        .Teachers.Single(t => t.TeacherId == Id);
                    entity.LeadTeacher = teacher;
                }
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
