namespace ConcertGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MediaUploadDateMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Media", "UploadDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Media", "UploadDate");
        }
    }
}
