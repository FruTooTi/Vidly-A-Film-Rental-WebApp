namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "birthday", c => c.DateTime(nullable: false));
        }
    }
}
