namespace ConcertGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UrlFileMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "Url");
        }
    }
}
