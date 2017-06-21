namespace ConcertGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MediaUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Media", "Location", c => c.String());
            AddColumn("dbo.Media", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Media", "Name");
            DropColumn("dbo.Media", "Location");
        }
    }
}
