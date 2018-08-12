namespace Accentis.Database.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetble : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.VenderMachines");
            AlterColumn("dbo.VenderMachines", "ProductId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.VenderMachines", "ProductId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.VenderMachines");
            AlterColumn("dbo.VenderMachines", "ProductId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.VenderMachines", "ProductId");
        }
    }
}
