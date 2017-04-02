namespace AspnetMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeModelRole2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SecModelRoles", "SecModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.SecModelRoles", "SecModelId");
            AddForeignKey("dbo.SecModelRoles", "SecModelId", "dbo.SecModels", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecModelRoles", "SecModelId", "dbo.SecModels");
            DropIndex("dbo.SecModelRoles", new[] { "SecModelId" });
            DropColumn("dbo.SecModelRoles", "SecModelId");
        }
    }
}
