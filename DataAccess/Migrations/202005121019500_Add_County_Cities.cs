namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_County_Cities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "County_Id", c => c.Guid());
            CreateIndex("dbo.Cities", "County_Id");
            AddForeignKey("dbo.Cities", "County_Id", "dbo.Counties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "County_Id", "dbo.Counties");
            DropIndex("dbo.Cities", new[] { "County_Id" });
            DropColumn("dbo.Cities", "County_Id");
        }
    }
}
