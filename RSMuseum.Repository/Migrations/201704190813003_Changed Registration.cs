namespace RSMuseum.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRegistration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        ZipCodeTableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.ZipCodeTables", t => t.ZipCodeTableId, cascadeDelete: true)
                .Index(t => t.ZipCodeTableId);
            
            CreateTable(
                "dbo.ZipCodeTables",
                c => new
                    {
                        ZipCodeTableId = c.Int(nullable: false, identity: true),
                        ZipCode = c.Int(nullable: false),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ZipCodeTableId);
            
            CreateTable(
                "dbo.Guilds",
                c => new
                    {
                        GuildId = c.Int(nullable: false, identity: true),
                        GuildName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GuildId);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        VolunteerId = c.Int(nullable: false, identity: true),
                        MembershipNumber = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VolunteerId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        AddressId = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        Hours = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        GuildId = c.Int(nullable: false),
                        VolunteerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegistrationId)
                .ForeignKey("dbo.Guilds", t => t.GuildId, cascadeDelete: true)
                .ForeignKey("dbo.Volunteers", t => t.VolunteerId, cascadeDelete: true)
                .Index(t => t.GuildId)
                .Index(t => t.VolunteerId);
            
            CreateTable(
                "dbo.VolunteerGuilds",
                c => new
                    {
                        Volunteer_VolunteerId = c.Int(nullable: false),
                        Guild_GuildId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Volunteer_VolunteerId, t.Guild_GuildId })
                .ForeignKey("dbo.Volunteers", t => t.Volunteer_VolunteerId, cascadeDelete: true)
                .ForeignKey("dbo.Guilds", t => t.Guild_GuildId, cascadeDelete: true)
                .Index(t => t.Volunteer_VolunteerId)
                .Index(t => t.Guild_GuildId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "VolunteerId", "dbo.Volunteers");
            DropForeignKey("dbo.Registrations", "GuildId", "dbo.Guilds");
            DropForeignKey("dbo.Volunteers", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.VolunteerGuilds", "Guild_GuildId", "dbo.Guilds");
            DropForeignKey("dbo.VolunteerGuilds", "Volunteer_VolunteerId", "dbo.Volunteers");
            DropForeignKey("dbo.Addresses", "ZipCodeTableId", "dbo.ZipCodeTables");
            DropIndex("dbo.VolunteerGuilds", new[] { "Guild_GuildId" });
            DropIndex("dbo.VolunteerGuilds", new[] { "Volunteer_VolunteerId" });
            DropIndex("dbo.Registrations", new[] { "VolunteerId" });
            DropIndex("dbo.Registrations", new[] { "GuildId" });
            DropIndex("dbo.People", new[] { "AddressId" });
            DropIndex("dbo.Volunteers", new[] { "PersonId" });
            DropIndex("dbo.Addresses", new[] { "ZipCodeTableId" });
            DropTable("dbo.VolunteerGuilds");
            DropTable("dbo.Registrations");
            DropTable("dbo.People");
            DropTable("dbo.Volunteers");
            DropTable("dbo.Guilds");
            DropTable("dbo.ZipCodeTables");
            DropTable("dbo.Addresses");
        }
    }
}
