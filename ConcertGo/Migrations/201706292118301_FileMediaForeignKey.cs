namespace ConcertGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileMediaForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "MediaId", "dbo.Media");
            DropIndex("dbo.Files", new[] { "MediaId" });
            AlterColumn("dbo.Files", "MediaId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Files", "MediaId");
            AddForeignKey("dbo.Files", "MediaId", "dbo.Media", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "MediaId", "dbo.Media");
            DropIndex("dbo.Files", new[] { "MediaId" });
            AlterColumn("dbo.Files", "MediaId", c => c.Guid());
            CreateIndex("dbo.Files", "MediaId");
            AddForeignKey("dbo.Files", "MediaId", "dbo.Media", "Id");
        }
    }
}
