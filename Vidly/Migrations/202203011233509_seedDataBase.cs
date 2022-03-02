namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedDataBase : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6f979b5f-53f1-4ab6-8b0f-bb0cac3cdd48', N'guest@vidly.com', 0, N'ANE98kye2KP3AenUZVx93iJ8aVeR7a9HNffekGXA7mpJZSiWuRXiCp1cydnI0z+eOA==', N'ed1203bb-d687-4302-b96f-da187376d078', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fabf6902-8326-4930-8af8-63cd44351736', N'admin@vidly.com', 0, N'ACHz0GeCR0zqfMvMldP6Kn/RUxEFsTePlfH17UxCf9g53mb7W4KFq42NOqF9/EbLVQ==', N'24be9466-412e-43fc-963a-e664a43af026', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9b85925d-7b1c-454b-aefe-42e1ad3b23df', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fabf6902-8326-4930-8af8-63cd44351736', N'9b85925d-7b1c-454b-aefe-42e1ad3b23df')
");
        }
        
        public override void Down()
        {
        }
    }
}
