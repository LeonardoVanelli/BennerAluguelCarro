namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Aluguels", "Status_Id", c => c.Int());
            CreateIndex("dbo.Aluguels", "Status_Id");
            AddForeignKey("dbo.Aluguels", "Status_Id", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluguels", "Status_Id", "dbo.Status");
            DropIndex("dbo.Aluguels", new[] { "Status_Id" });
            DropColumn("dbo.Aluguels", "Status_Id");
            DropTable("dbo.Status");
        }
    }
}
