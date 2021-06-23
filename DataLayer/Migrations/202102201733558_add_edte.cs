namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_edte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "Imagename", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "Imagename", c => c.Int(nullable: false));
        }
    }
}
