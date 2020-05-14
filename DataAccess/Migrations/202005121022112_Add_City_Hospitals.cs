namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_City_Hospitals : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BloodTypePersons", newName: "PersonBloodTypes");
            DropPrimaryKey("dbo.PersonBloodTypes");
            AddColumn("dbo.Hospitals", "City_Id", c => c.Guid());
            AddPrimaryKey("dbo.PersonBloodTypes", new[] { "Person_Id", "BloodType_Id" });
            CreateIndex("dbo.Hospitals", "City_Id");
            AddForeignKey("dbo.Hospitals", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hospitals", "City_Id", "dbo.Cities");
            DropIndex("dbo.Hospitals", new[] { "City_Id" });
            DropPrimaryKey("dbo.PersonBloodTypes");
            DropColumn("dbo.Hospitals", "City_Id");
            AddPrimaryKey("dbo.PersonBloodTypes", new[] { "BloodType_Id", "Person_Id" });
            RenameTable(name: "dbo.PersonBloodTypes", newName: "BloodTypePersons");
        }
    }
}
