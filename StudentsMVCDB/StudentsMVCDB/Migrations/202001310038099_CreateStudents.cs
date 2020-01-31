namespace StudentsMVCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStudents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        StudentAddress_Id = c.Int(),
                        StudentClass_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.StudentAddress_Id)
                .ForeignKey("dbo.Classes", t => t.StudentClass_Id)
                .Index(t => t.StudentAddress_Id)
                .Index(t => t.StudentClass_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentClass_Id", "dbo.Classes");
            DropForeignKey("dbo.Students", "StudentAddress_Id", "dbo.Addresses");
            DropIndex("dbo.Students", new[] { "StudentClass_Id" });
            DropIndex("dbo.Students", new[] { "StudentAddress_Id" });
            DropTable("dbo.Addresses");
            DropTable("dbo.Students");
        }
    }
}
