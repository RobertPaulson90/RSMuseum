namespace RSMuseum.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmembershipnumberpropertytovolunteer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteers", "MembershipNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteers", "MembershipNumber");
        }
    }
}
