namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_City_Persons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "City_Id", c => c.Guid());
            CreateIndex("dbo.People", "City_Id");
            AddForeignKey("dbo.People", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "City_Id", "dbo.Cities");
            DropIndex("dbo.People", new[] { "City_Id" });
            DropColumn("dbo.People", "City_Id");
        }
    }
}
