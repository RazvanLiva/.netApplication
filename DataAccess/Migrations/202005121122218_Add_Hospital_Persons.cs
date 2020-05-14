namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Hospital_Persons : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.People", "Hospital_Id", c => c.Guid());
            CreateIndex("dbo.People", "Hospital_Id");
            AddForeignKey("dbo.People", "Hospital_Id", "dbo.Hospitals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Hospital_Id", "dbo.Hospitals");
            DropIndex("dbo.People", new[] { "Hospital_Id" });
            DropColumn("dbo.People", "Hospital_Id");
            RenameTable(name: "dbo.People", newName: "Persons");
        }
    }
}
