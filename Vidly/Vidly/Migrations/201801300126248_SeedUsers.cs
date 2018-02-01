namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0dae5138-8488-464c-8f5c-9b21f530464b', N'admin@vidly.com', 0, N'ANv7sJ9fcL/0ZtCif7UrHxjCj0cMyMWYF2Q1i4rg3G5WyrbwvxjEf+nSr/rbHE2U6Q==', N'b77dd478-3702-450b-935e-fd34e97ee97b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6fb5c99e-58b7-435b-800d-5618fd9d5011', N'guest@vidly.com', 0, N'AJ59H2jfhrh5dtQ0nYB8AENqzUWWQwJD6rwmayPuRn+tCA8myXV4fD59GVG88FiVgQ==', N'004fe8f4-f399-46ed-a7a3-4ef0c2db5e34', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'28f5a19e-6c34-489e-9499-c09771f12f26', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0dae5138-8488-464c-8f5c-9b21f530464b', N'28f5a19e-6c34-489e-9499-c09771f12f26')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
