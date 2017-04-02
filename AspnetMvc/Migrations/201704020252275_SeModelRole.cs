namespace AspnetMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeModelRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SecModelRoles", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.SecModelRoles", "RoleId");
            AddForeignKey("dbo.SecModelRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecModelRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.SecModelRoles", new[] { "RoleId" });
            DropColumn("dbo.SecModelRoles", "RoleId");
        }
    }
}
