namespace School.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseStudent", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.CourseStudent", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.CourseTeacher", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.CourseTeacher", "Teacher_Id", "dbo.Teacher");
            DropForeignKey("dbo.Activity", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.ActivityStudent", "Activity_Id", "dbo.Activity");
            DropForeignKey("dbo.ActivityStudent", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.DisciplineStudent", "Discipline_Id", "dbo.Discipline");
            DropForeignKey("dbo.DisciplineStudent", "Student_Id", "dbo.Student");
            DropIndex("dbo.Activity", new[] { "TeacherId" });
            DropIndex("dbo.CourseStudent", new[] { "Course_Id" });
            DropIndex("dbo.CourseStudent", new[] { "Student_Id" });
            DropIndex("dbo.CourseTeacher", new[] { "Course_Id" });
            DropIndex("dbo.CourseTeacher", new[] { "Teacher_Id" });
            DropIndex("dbo.ActivityStudent", new[] { "Activity_Id" });
            DropIndex("dbo.ActivityStudent", new[] { "Student_Id" });
            DropIndex("dbo.DisciplineStudent", new[] { "Discipline_Id" });
            DropIndex("dbo.DisciplineStudent", new[] { "Student_Id" });
            DropPrimaryKey("dbo.Teacher");
            DropPrimaryKey("dbo.Discipline");
            AddColumn("dbo.Student", "Activity_Id", c => c.Int());
            AddColumn("dbo.Student", "Discipline_DisciplineId", c => c.Int());
            AddColumn("dbo.Teacher", "TeacherId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Teacher", "TeacherName", c => c.String());
            AddColumn("dbo.Teacher", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Teacher", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Course", "Teacher_TeacherId", c => c.Int());
            AddColumn("dbo.Discipline", "DisciplineId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Discipline", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Discipline", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Course", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Teacher", "TeacherId");
            AddPrimaryKey("dbo.Discipline", "DisciplineId");
            CreateIndex("dbo.Student", "Activity_Id");
            CreateIndex("dbo.Student", "Discipline_DisciplineId");
            CreateIndex("dbo.Course", "Teacher_TeacherId");
            AddForeignKey("dbo.Student", "Activity_Id", "dbo.Activity", "Id");
            AddForeignKey("dbo.Student", "Discipline_DisciplineId", "dbo.Discipline", "DisciplineId");
            AddForeignKey("dbo.Course", "Teacher_TeacherId", "dbo.Teacher", "TeacherId");
            DropColumn("dbo.Activity", "TeacherId");
            DropColumn("dbo.Teacher", "Id");
            DropColumn("dbo.Discipline", "Id");
            DropColumn("dbo.Discipline", "Date");
            DropTable("dbo.CourseStudent");
            DropTable("dbo.CourseTeacher");
            DropTable("dbo.ActivityStudent");
            DropTable("dbo.DisciplineStudent");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DisciplineStudent",
                c => new
                    {
                        Discipline_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discipline_Id, t.Student_Id });
            
            CreateTable(
                "dbo.ActivityStudent",
                c => new
                    {
                        Activity_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Activity_Id, t.Student_Id });
            
            CreateTable(
                "dbo.CourseTeacher",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Teacher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Teacher_Id });
            
            CreateTable(
                "dbo.CourseStudent",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Student_Id });
            
            AddColumn("dbo.Discipline", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Discipline", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Teacher", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Activity", "TeacherId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Course", "Teacher_TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Student", "Discipline_DisciplineId", "dbo.Discipline");
            DropForeignKey("dbo.Student", "Activity_Id", "dbo.Activity");
            DropIndex("dbo.Course", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Student", new[] { "Discipline_DisciplineId" });
            DropIndex("dbo.Student", new[] { "Activity_Id" });
            DropPrimaryKey("dbo.Discipline");
            DropPrimaryKey("dbo.Teacher");
            AlterColumn("dbo.Course", "Name", c => c.String());
            DropColumn("dbo.Discipline", "CreatedUtc");
            DropColumn("dbo.Discipline", "ModifiedUtc");
            DropColumn("dbo.Discipline", "DisciplineId");
            DropColumn("dbo.Course", "Teacher_TeacherId");
            DropColumn("dbo.Teacher", "ModifiedUtc");
            DropColumn("dbo.Teacher", "CreatedUtc");
            DropColumn("dbo.Teacher", "TeacherName");
            DropColumn("dbo.Teacher", "TeacherId");
            DropColumn("dbo.Student", "Discipline_DisciplineId");
            DropColumn("dbo.Student", "Activity_Id");
            AddPrimaryKey("dbo.Discipline", "Id");
            AddPrimaryKey("dbo.Teacher", "Id");
            CreateIndex("dbo.DisciplineStudent", "Student_Id");
            CreateIndex("dbo.DisciplineStudent", "Discipline_Id");
            CreateIndex("dbo.ActivityStudent", "Student_Id");
            CreateIndex("dbo.ActivityStudent", "Activity_Id");
            CreateIndex("dbo.CourseTeacher", "Teacher_Id");
            CreateIndex("dbo.CourseTeacher", "Course_Id");
            CreateIndex("dbo.CourseStudent", "Student_Id");
            CreateIndex("dbo.CourseStudent", "Course_Id");
            CreateIndex("dbo.Activity", "TeacherId");
            AddForeignKey("dbo.DisciplineStudent", "Student_Id", "dbo.Student", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DisciplineStudent", "Discipline_Id", "dbo.Discipline", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ActivityStudent", "Student_Id", "dbo.Student", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ActivityStudent", "Activity_Id", "dbo.Activity", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Activity", "TeacherId", "dbo.Teacher", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseTeacher", "Teacher_Id", "dbo.Teacher", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseTeacher", "Course_Id", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseStudent", "Student_Id", "dbo.Student", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseStudent", "Course_Id", "dbo.Course", "Id", cascadeDelete: true);
        }
    }
}
