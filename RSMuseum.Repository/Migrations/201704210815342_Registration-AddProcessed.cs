namespace RSMuseum.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistrationAddProcessed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "Processed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "Processed");
        }
    }
}
