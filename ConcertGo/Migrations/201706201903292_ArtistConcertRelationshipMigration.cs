namespace ConcertGo.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ArtistConcertRelationshipMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artists", "Concert_Id", "dbo.Concerts");
            DropIndex("dbo.Artists", new[] { "Concert_Id" });
            CreateTable(
                "dbo.ConcertArtists",
                c => new
                    {
                        Concert_Id = c.Guid(nullable: false),
                        Artist_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Concert_Id, t.Artist_Id })
                .ForeignKey("dbo.Concerts", t => t.Concert_Id, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .Index(t => t.Concert_Id)
                .Index(t => t.Artist_Id);
            
            DropColumn("dbo.Artists", "Concert_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "Concert_Id", c => c.Guid());
            DropForeignKey("dbo.ConcertArtists", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.ConcertArtists", "Concert_Id", "dbo.Concerts");
            DropIndex("dbo.ConcertArtists", new[] { "Artist_Id" });
            DropIndex("dbo.ConcertArtists", new[] { "Concert_Id" });
            DropTable("dbo.ConcertArtists");
            CreateIndex("dbo.Artists", "Concert_Id");
            AddForeignKey("dbo.Artists", "Concert_Id", "dbo.Concerts", "Id");
        }
    }
}
