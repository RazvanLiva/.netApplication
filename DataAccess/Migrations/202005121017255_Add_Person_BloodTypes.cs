namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Person_BloodTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonBloodTypes",
                c => new
                    {
                        Person_Id = c.Guid(nullable: false),
                        BloodType_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.BloodType_Id })
                .ForeignKey("dbo.Persons", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.BloodTypes", t => t.BloodType_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.BloodType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonBloodTypes", "BloodType_Id", "dbo.BloodTypes");
            DropForeignKey("dbo.PersonBloodTypes", "Person_Id", "dbo.Persons");
            DropIndex("dbo.PersonBloodTypes", new[] { "BloodType_Id" });
            DropIndex("dbo.PersonBloodTypes", new[] { "Person_Id" });
            DropTable("dbo.PersonBloodTypes");
        }
    }
}
