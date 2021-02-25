using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //LeadTeacher = model.LeadTeacher,
                StudentList = model.StudentList,

            };
            //will have to fix identity models "Activity" in class
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Activities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ActivityUpdate> GetAllActivity()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Activities
                        .Select(
                            e =>
                                new ActivityUpdate
                                {
                                    ActivityId = e.Id,
                                    //ActivityName = e.Name
                                }
                        );

                return query.ToArray();
            }
        }

        public ActivityUpdate GetActivityById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single(e => e.Id == id);
                return
                    new ActivityUpdate
                    {
                        ActivityId = entity.Id,
                        //ActivityName = entity.Name,
                        //ActivityDuration = entity.Duration,
                        ActivityTeacherId = entity.TeacherId
                        //LeadTeacher = entity.LeadTeacher,
                        //StudentList = entity.StudentList,

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
                            //entity.Name = model.ActivityName;
                            //entity.Duration = model.ActivityDuration;

                return ctx.SaveChanges() == 1;

            }

        }

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
    }
}
