namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "tags");
        }
    }
}
