namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userIsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "isDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "isDeleted");
        }
    }
}
