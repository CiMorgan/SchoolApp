namespace School.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        GradeLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Department = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Department = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Discipline",
                c => new
                    {
                        DisciplineId = c.Int(nullable: false, identity: true),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Comment = c.String(),
                        Expelled = c.Boolean(nullable: false),
                        DisciplineType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DisciplineId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.StudentActivity",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Activity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Activity_Id })
                .ForeignKey("dbo.Student", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Activity", t => t.Activity_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Activity_Id);
            
            CreateTable(
                "dbo.CourseStudent",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Student_Id })
                .ForeignKey("dbo.Course", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.TeacherCourse",
                c => new
                    {
                        Teacher_TeacherId = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_TeacherId, t.Course_Id })
                .ForeignKey("dbo.Teacher", t => t.Teacher_TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Teacher_TeacherId)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.DisciplineStudent",
                c => new
                    {
                        Discipline_DisciplineId = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discipline_DisciplineId, t.Student_Id })
                .ForeignKey("dbo.Discipline", t => t.Discipline_DisciplineId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Discipline_DisciplineId)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.DisciplineStudent", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.DisciplineStudent", "Discipline_DisciplineId", "dbo.Discipline");
            DropForeignKey("dbo.TeacherCourse", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.TeacherCourse", "Teacher_TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.CourseStudent", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.CourseStudent", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.StudentActivity", "Activity_Id", "dbo.Activity");
            DropForeignKey("dbo.StudentActivity", "Student_Id", "dbo.Student");
            DropIndex("dbo.DisciplineStudent", new[] { "Student_Id" });
            DropIndex("dbo.DisciplineStudent", new[] { "Discipline_DisciplineId" });
            DropIndex("dbo.TeacherCourse", new[] { "Course_Id" });
            DropIndex("dbo.TeacherCourse", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.CourseStudent", new[] { "Student_Id" });
            DropIndex("dbo.CourseStudent", new[] { "Course_Id" });
            DropIndex("dbo.StudentActivity", new[] { "Activity_Id" });
            DropIndex("dbo.StudentActivity", new[] { "Student_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.DisciplineStudent");
            DropTable("dbo.TeacherCourse");
            DropTable("dbo.CourseStudent");
            DropTable("dbo.StudentActivity");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Discipline");
            DropTable("dbo.Teacher");
            DropTable("dbo.Course");
            DropTable("dbo.Student");
            DropTable("dbo.Activity");
        }
    }
}
