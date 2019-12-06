namespace MyTimeTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleHireDateEmployeeClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Role", c => c.String());
            AddColumn("dbo.Employees", "HireDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "HireDate");
            DropColumn("dbo.Employees", "Role");
        }
    }
}
