namespace MyTimeTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDOBEmployeeClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "DOB");
        }
    }
}
