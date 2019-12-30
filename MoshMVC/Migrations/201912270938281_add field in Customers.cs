namespace MoshMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfieldinCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MemberSipTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MemberSipTypeId");
        }
    }
}
