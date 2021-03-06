namespace School.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class March4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DisciplineStudents", "Discipline_DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.DisciplineStudents", "Student_Id", "dbo.Students");
            DropIndex("dbo.DisciplineStudents", new[] { "Discipline_DisciplineId" });
            DropIndex("dbo.DisciplineStudents", new[] { "Student_Id" });
            AddColumn("dbo.Students", "Discipline_DisciplineId", c => c.Int());
            AddColumn("dbo.Disciplines", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Disciplines", "Student_Id", c => c.Int());
            CreateIndex("dbo.Students", "Discipline_DisciplineId");
            CreateIndex("dbo.Disciplines", "StudentId");
            CreateIndex("dbo.Disciplines", "Student_Id");
            AddForeignKey("dbo.Disciplines", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Discipline_DisciplineId", "dbo.Disciplines", "DisciplineId");
            AddForeignKey("dbo.Disciplines", "Student_Id", "dbo.Students", "Id");
            DropTable("dbo.DisciplineStudents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DisciplineStudents",
                c => new
                    {
                        Discipline_DisciplineId = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discipline_DisciplineId, t.Student_Id });
            
            DropForeignKey("dbo.Disciplines", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Discipline_DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.Disciplines", "StudentId", "dbo.Students");
            DropIndex("dbo.Disciplines", new[] { "Student_Id" });
            DropIndex("dbo.Disciplines", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "Discipline_DisciplineId" });
            DropColumn("dbo.Disciplines", "Student_Id");
            DropColumn("dbo.Disciplines", "StudentId");
            DropColumn("dbo.Students", "Discipline_DisciplineId");
            CreateIndex("dbo.DisciplineStudents", "Student_Id");
            CreateIndex("dbo.DisciplineStudents", "Discipline_DisciplineId");
            AddForeignKey("dbo.DisciplineStudents", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DisciplineStudents", "Discipline_DisciplineId", "dbo.Disciplines", "DisciplineId", cascadeDelete: true);
        }
    }
}
