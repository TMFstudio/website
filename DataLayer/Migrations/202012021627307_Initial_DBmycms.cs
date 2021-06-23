namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_DBmycms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.camment_page",
                c => new
                    {
                        commentID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Comment = c.String(nullable: false, maxLength: 450),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.commentID)
                .ForeignKey("dbo.Pages", t => t.PageID, cascadeDelete: true)
                .Index(t => t.PageID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        ShortDiscription = c.String(nullable: false, maxLength: 350),
                        Text = c.String(nullable: false),
                        Visit = c.Int(nullable: false),
                        Imagename = c.Int(nullable: false),
                        ShowInSliders = c.Boolean(nullable: false),
                        CreatDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.group_page", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.group_page",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        groupTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "GroupID", "dbo.group_page");
            DropForeignKey("dbo.camment_page", "PageID", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "GroupID" });
            DropIndex("dbo.camment_page", new[] { "PageID" });
            DropTable("dbo.group_page");
            DropTable("dbo.Pages");
            DropTable("dbo.camment_page");
        }
    }
}
