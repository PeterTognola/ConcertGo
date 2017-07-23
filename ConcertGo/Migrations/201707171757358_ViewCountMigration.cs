namespace ConcertGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewCountMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "Views", c => c.Int(nullable: false));
            AddColumn("dbo.Concerts", "Views", c => c.Int(nullable: false));
            AddColumn("dbo.Media", "UploadDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Media", "UploadDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Media", "UploadDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Media", "UploadDateTime");
            DropColumn("dbo.Concerts", "Views");
            DropColumn("dbo.Artists", "Views");
        }
    }
}
