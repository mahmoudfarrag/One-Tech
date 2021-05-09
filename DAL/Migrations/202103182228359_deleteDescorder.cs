namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteDescorder : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Description", c => c.String());
        }
    }
}
