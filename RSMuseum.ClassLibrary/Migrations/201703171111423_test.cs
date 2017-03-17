namespace RSMuseum.ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        ZipCodeId_ZipCodeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ZipCodeTables", t => t.ZipCodeId_ZipCodeId)
                .Index(t => t.ZipCodeId_ZipCodeId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Guild_GuildId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Id)
                .ForeignKey("dbo.Guilds", t => t.Guild_GuildId)
                .Index(t => t.Id)
                .Index(t => t.Guild_GuildId);
            
            CreateTable(
                "dbo.Guilds",
                c => new
                    {
                        GuildId = c.Int(nullable: false, identity: true),
                        GuildName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GuildId);
            
            CreateTable(
                "dbo.ZipCodeTables",
                c => new
                    {
                        ZipCodeId = c.Int(nullable: false, identity: true),
                        ZipCode = c.Int(nullable: false),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ZipCodeId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        Hours = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        CurrentGuildId = c.Int(nullable: false),
                        VolunteerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegistrationId)
                .ForeignKey("dbo.Volunteers", t => t.VolunteerId, cascadeDelete: true)
                .Index(t => t.VolunteerId);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "VolunteerId", "dbo.Volunteers");
            DropForeignKey("dbo.Addresses", "ZipCodeId_ZipCodeId", "dbo.ZipCodeTables");
            DropForeignKey("dbo.People", "Guild_GuildId", "dbo.Guilds");
            DropForeignKey("dbo.People", "Id", "dbo.Addresses");
            DropIndex("dbo.Registrations", new[] { "VolunteerId" });
            DropIndex("dbo.People", new[] { "Guild_GuildId" });
            DropIndex("dbo.People", new[] { "Id" });
            DropIndex("dbo.Addresses", new[] { "ZipCodeId_ZipCodeId" });
            DropTable("dbo.Volunteers");
            DropTable("dbo.Registrations");
            DropTable("dbo.ZipCodeTables");
            DropTable("dbo.Guilds");
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
