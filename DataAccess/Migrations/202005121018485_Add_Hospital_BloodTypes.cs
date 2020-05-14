namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Hospital_BloodTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BloodTypes", "Hospital_Id", c => c.Guid());
            CreateIndex("dbo.BloodTypes", "Hospital_Id");
            AddForeignKey("dbo.BloodTypes", "Hospital_Id", "dbo.Hospitals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BloodTypes", "Hospital_Id", "dbo.Hospitals");
            DropIndex("dbo.BloodTypes", new[] { "Hospital_Id" });
            DropColumn("dbo.BloodTypes", "Hospital_Id");
        }
    }
}
