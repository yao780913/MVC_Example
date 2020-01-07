namespace MoshMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerNamelength10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
