namespace AspnetMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        Phone = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(nullable: false),
                        DatePosted = c.String(),
                        TimePosted = c.String(),
                        DateEdited = c.String(),
                        TimeEdited = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecActivityRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        SecActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.SecActivities", t => t.SecActivityId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.SecActivityId);
            
            CreateTable(
                "dbo.SecActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecModelAttributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SecModelId = c.Int(nullable: false),
                        Name = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SecModels", t => t.SecModelId, cascadeDelete: true)
                .Index(t => t.SecModelId);
            
            CreateTable(
                "dbo.SecModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecModelAttributeRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SecModelRoleId = c.Int(nullable: false),
                        SecModelAttributeId = c.Int(nullable: false),
                        AllowCreate = c.Boolean(nullable: false),
                        AllowRead = c.Boolean(nullable: false),
                        AllowUpdate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SecModelAttributes", t => t.SecModelAttributeId, cascadeDelete: true)
                .ForeignKey("dbo.SecModelRoles", t => t.SecModelRoleId, cascadeDelete: true)
                .Index(t => t.SecModelRoleId)
                .Index(t => t.SecModelAttributeId);
            
            CreateTable(
                "dbo.SecModelRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AllowCreate = c.Boolean(nullable: false),
                        AllowRead = c.Boolean(nullable: false),
                        AllowUpdate = c.Boolean(nullable: false),
                        AllowDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecModelAttributeRoles", "SecModelRoleId", "dbo.SecModelRoles");
            DropForeignKey("dbo.SecModelAttributeRoles", "SecModelAttributeId", "dbo.SecModelAttributes");
            DropForeignKey("dbo.SecModelAttributes", "SecModelId", "dbo.SecModels");
            DropForeignKey("dbo.UserRols", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRols", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.SecActivityRoles", "SecActivityId", "dbo.SecActivities");
            DropForeignKey("dbo.SecActivityRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.SecModelAttributeRoles", new[] { "SecModelAttributeId" });
            DropIndex("dbo.SecModelAttributeRoles", new[] { "SecModelRoleId" });
            DropIndex("dbo.SecModelAttributes", new[] { "SecModelId" });
            DropIndex("dbo.UserRols", new[] { "RoleId" });
            DropIndex("dbo.UserRols", new[] { "UserId" });
            DropIndex("dbo.SecActivityRoles", new[] { "SecActivityId" });
            DropIndex("dbo.SecActivityRoles", new[] { "RoleId" });
            DropTable("dbo.SecModelRoles");
            DropTable("dbo.SecModelAttributeRoles");
            DropTable("dbo.SecModels");
            DropTable("dbo.SecModelAttributes");
            DropTable("dbo.Users");
            DropTable("dbo.UserRols");
            DropTable("dbo.SecActivities");
            DropTable("dbo.SecActivityRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Lists");
            DropTable("dbo.Addresses");
        }
    }
}
