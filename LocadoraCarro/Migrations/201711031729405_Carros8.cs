namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carros8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carroes", "ModeloId", "dbo.Modeloes");
            DropIndex("dbo.Carroes", new[] { "ModeloId" });
            AlterColumn("dbo.Carroes", "ModeloId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carroes", "ModeloId");
            AddForeignKey("dbo.Carroes", "ModeloId", "dbo.Modeloes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carroes", "ModeloId", "dbo.Modeloes");
            DropIndex("dbo.Carroes", new[] { "ModeloId" });
            AlterColumn("dbo.Carroes", "ModeloId", c => c.Int());
            CreateIndex("dbo.Carroes", "ModeloId");
            AddForeignKey("dbo.Carroes", "ModeloId", "dbo.Modeloes", "Id");
        }
    }
}
