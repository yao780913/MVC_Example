namespace MoshMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamefields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MemberShipTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "MemberSipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MemberSipTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "MemberShipTypeId");
        }
    }
}
