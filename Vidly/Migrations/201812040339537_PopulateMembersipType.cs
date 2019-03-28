using System.Data.Entity.Migrations;

namespace Vidly.Migrations
{

   public partial class PopulateMembersipType : DbMigration
   {
      public override void Up()
      {
         Sql("INSERT INTO MembershipTypes (Id,SignUpFee,DurationInMonth,DiscountFee) VALUES(1, 0, 0, 0)");
         Sql("INSERT INTO MembershipTypes (Id,SignUpFee,DurationInMonth,DiscountFee) VALUES(2, 30, 1, 10)");
         Sql("INSERT INTO MembershipTypes (Id,SignUpFee,DurationInMonth,DiscountFee) VALUES(3, 90, 3, 15)");
         Sql("INSERT INTO MembershipTypes (Id,SignUpFee,DurationInMonth,DiscountFee) VALUES(4, 300, 12, 20)");
      }

      public override void Down()
      {
      }
   }
}