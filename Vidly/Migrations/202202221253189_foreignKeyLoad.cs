namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeyLoad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "genreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "genreId");
            AddForeignKey("dbo.Movies", "genreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "genre", c => c.String());
            DropForeignKey("dbo.Movies", "genreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genreId" });
            DropColumn("dbo.Movies", "genreId");
        }
    }
}
