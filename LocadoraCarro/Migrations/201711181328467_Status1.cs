namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Aluguels", "Status_Id", "dbo.Status");
            DropIndex("dbo.Aluguels", new[] { "Status_Id" });
            RenameColumn(table: "dbo.Aluguels", name: "Status_Id", newName: "StatusId");
            AlterColumn("dbo.Aluguels", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Aluguels", "StatusId");
            AddForeignKey("dbo.Aluguels", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluguels", "StatusId", "dbo.Status");
            DropIndex("dbo.Aluguels", new[] { "StatusId" });
            AlterColumn("dbo.Aluguels", "StatusId", c => c.Int());
            RenameColumn(table: "dbo.Aluguels", name: "StatusId", newName: "Status_Id");
            CreateIndex("dbo.Aluguels", "Status_Id");
            AddForeignKey("dbo.Aluguels", "Status_Id", "dbo.Status", "Id");
        }
    }
}
