namespace RSMuseum.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_DateTimeRegistered : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "DateTimeRegistered", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "DateTimeRegistered");
        }
    }
}
