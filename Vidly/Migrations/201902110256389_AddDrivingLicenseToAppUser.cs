using System.Data.Entity.Migrations;

namespace Vidly.Migrations
{

   public partial class AddDrivingLicenseToAppUser : DbMigration
   {
      public override void Up()
      {
         AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
      }

      public override void Down()
      {
         DropColumn("dbo.AspNetUsers", "DrivingLicense");
      }
   }
}