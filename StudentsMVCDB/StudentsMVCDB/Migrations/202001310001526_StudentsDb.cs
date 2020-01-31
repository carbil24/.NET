namespace StudentsMVCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentsDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Classes");
        }
    }
}
