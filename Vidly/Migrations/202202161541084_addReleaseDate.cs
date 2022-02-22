namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReleaseDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "releaseDate");
        }
    }
}
