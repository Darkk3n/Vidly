using System.Data.Entity.Migrations;

namespace Vidly.Migrations
{

   public partial class AddIsSubcribedToCustomer : DbMigration
   {
      public override void Up()
      {
         AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
      }

      public override void Down()
      {
         DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
      }
   }
}