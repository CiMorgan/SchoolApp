namespace School.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4MAR21x2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "LastName", c => c.String());
            AlterColumn("dbo.Teachers", "FirstName", c => c.String());
        }
    }
}
