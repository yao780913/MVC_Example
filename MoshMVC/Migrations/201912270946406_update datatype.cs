namespace MoshMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "MemberShipTypeId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "MemberShipTypeId", c => c.Int(nullable: false));
        }
    }
}
