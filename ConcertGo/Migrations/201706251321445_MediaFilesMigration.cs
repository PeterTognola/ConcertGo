namespace ConcertGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MediaFilesMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Location = c.String(),
                        Media_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Media", t => t.Media_Id)
                .Index(t => t.Media_Id);
            
            AddColumn("dbo.Media", "Comment", c => c.String());
            DropColumn("dbo.Media", "Type");
            DropColumn("dbo.Media", "Location");
            DropColumn("dbo.Media", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Media", "Name", c => c.String());
            AddColumn("dbo.Media", "Location", c => c.String());
            AddColumn("dbo.Media", "Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.Files", "Media_Id", "dbo.Media");
            DropIndex("dbo.Files", new[] { "Media_Id" });
            DropColumn("dbo.Media", "Comment");
            DropTable("dbo.Files");
        }
    }
}
