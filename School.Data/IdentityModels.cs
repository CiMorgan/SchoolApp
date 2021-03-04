using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace School.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Activity> Activities { get; set; }

        //public class StudentCourse
        //{
        //    public int StudentId { get; set; }
        //    public Student Student { get; set; }

        //    public int CourseId { get; set; }
        //    public Course Course { get; set; }
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    {
        //        modelBuilder
        //            .Conventions
        //            .Remove<PluralizingTableNameConvention>();

        //        modelBuilder
        //            .Configurations
        //            .Add(new IdentityUserLoginConfiguration())
        //            .Add(new IdentityUserRoleConfiguration());

        //        modelBuilder.Entity<Student>()
        //                    .HasMany<Course>(s => s.CourseList)
        //                    .WithMany(c => c.StudentList)
        //                    .Map(sc =>
        //                            {
        //                                sc.MapLeftKey("StudentId");
        //                                sc.MapRightKey("CourseId");
        //                                sc.ToTable("StudentCourse");
        //                            });
        //    }
        //}
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }

    }
}