namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_County_Adresses : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PersonBloodTypes", newName: "BloodTypePersons");
            DropPrimaryKey("dbo.BloodTypePersons");
            AddPrimaryKey("dbo.BloodTypePersons", new[] { "BloodType_Id", "Person_Id" });
            CreateIndex("dbo.Addresses", "Id");
            AddForeignKey("dbo.Addresses", "Id", "dbo.Counties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Id", "dbo.Counties");
            DropIndex("dbo.Addresses", new[] { "Id" });
            DropPrimaryKey("dbo.BloodTypePersons");
            AddPrimaryKey("dbo.BloodTypePersons", new[] { "Person_Id", "BloodType_Id" });
            RenameTable(name: "dbo.BloodTypePersons", newName: "PersonBloodTypes");
        }
    }
}
