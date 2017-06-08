namespace RSMuseum.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VolunteerAddTotalApprovedHours : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteers", "TotalApprovedHours", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteers", "TotalApprovedHours");
        }
    }
}
