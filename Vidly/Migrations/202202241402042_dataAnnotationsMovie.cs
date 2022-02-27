namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotationsMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "name", c => c.String());
        }
    }
}
