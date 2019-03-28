using System.Data.Entity.Migrations;

namespace Vidly.Migrations
{

   public partial class SeedUsers : DbMigration
   {
      public override void Up()
      {
         Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b5fae3ed-cc28-4c50-8d4b-735b98a583f1', N'admin@vidly.com', 0, N'AFd9bwU4nfP2MdQkqWQyrAgepyYSI9syNWPrnuidCTsX9lgAuAXVdgUULg0Vt/7NWA==', N'49e00a5a-77b5-4871-b58d-499ddc224ca6', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

         INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c1b293c1-7726-483d-ace7-fb46f86b45f7', N'gerardo.aguilar01@outlook.com', 0, N'AEei6/Tx05Pic6N2T6sIoNwL/N2yobfAVWHbn0+asMatJF+tOCaQzzHvZwMwlHqC/w==', N'd48d57c9-2087-4b21-a6cc-d94ab9e80ecc', NULL, 0, 0, NULL, 1, 0, N'gerardo.aguilar01@outlook.com')

         INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ea0c9098-96c7-43d5-89e7-985e50ecad66', N'guest@vidly.com', 0, N'AJhnccOQ2ueo3Z1eo8l1MXWodfuiTM+I/MMRP+TBc5CURk1Z2QAxKWARNsSyzuYRpg==', N'28f9f121-3961-4771-8d16-949923d3e2ab', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

         INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4eca6e69-d636-4ad1-8a91-ce5a7a7b9493', N'CanManageMovies')

         INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b5fae3ed-cc28-4c50-8d4b-735b98a583f1', N'4eca6e69-d636-4ad1-8a91-ce5a7a7b9493')");
      }

      public override void Down()
      {
      }
   }
}