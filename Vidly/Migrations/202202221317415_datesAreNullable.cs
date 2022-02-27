namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datesAreNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "dateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "dateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
        }
    }
}
