namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "InfectedWithCovid", c => c.String());
            AddColumn("dbo.People", "Recovery", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Recovery");
            DropColumn("dbo.People", "InfectedWithCovid");
        }
    }
}
