namespace ConcertGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileHandleMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "UploadDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Files", "HasMedia", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "HasMedia");
            DropColumn("dbo.Files", "UploadDateTime");
        }
    }
}
