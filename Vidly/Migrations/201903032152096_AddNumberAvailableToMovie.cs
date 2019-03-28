using System.Data.Entity.Migrations;

namespace Vidly.Migrations
{

   public partial class AddNumberAvailableToMovie : DbMigration
   {
      public override void Up()
      {
         AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
         Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
      }

      public override void Down()
      {
         DropColumn("dbo.Movies", "NumberAvailable");
      }
   }
}