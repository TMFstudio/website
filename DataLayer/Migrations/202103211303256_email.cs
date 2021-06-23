namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.camment_page", "Eamil", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.camment_page", "Name", c => c.String(nullable: false, maxLength: 450));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.camment_page", "Name", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.camment_page", "Eamil");
        }
    }
}
