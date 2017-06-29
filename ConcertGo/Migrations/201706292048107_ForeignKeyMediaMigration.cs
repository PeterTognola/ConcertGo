namespace ConcertGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyMediaMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Media_Id", "dbo.Media");
            DropIndex("dbo.Files", new[] { "Media_Id" });
            RenameColumn(table: "dbo.Files", name: "Media_Id", newName: "MediaId");
            AlterColumn("dbo.Files", "MediaId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Files", "MediaId");
            AddForeignKey("dbo.Files", "MediaId", "dbo.Media", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "MediaId", "dbo.Media");
            DropIndex("dbo.Files", new[] { "MediaId" });
            AlterColumn("dbo.Files", "MediaId", c => c.Guid());
            RenameColumn(table: "dbo.Files", name: "MediaId", newName: "Media_Id");
            CreateIndex("dbo.Files", "Media_Id");
            AddForeignKey("dbo.Files", "Media_Id", "dbo.Media", "Id");
        }
    }
}
