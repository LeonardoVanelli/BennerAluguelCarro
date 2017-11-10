namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carros3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modeloes", "Carro_Id", "dbo.Carroes");
            DropIndex("dbo.Modeloes", new[] { "Carro_Id" });
            AddColumn("dbo.Carroes", "Modelo_Id", c => c.Int());
            CreateIndex("dbo.Carroes", "Modelo_Id");
            AddForeignKey("dbo.Carroes", "Modelo_Id", "dbo.Modeloes", "Id");
            DropColumn("dbo.Modeloes", "Carro_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modeloes", "Carro_Id", c => c.Int());
            DropForeignKey("dbo.Carroes", "Modelo_Id", "dbo.Modeloes");
            DropIndex("dbo.Carroes", new[] { "Modelo_Id" });
            DropColumn("dbo.Carroes", "Modelo_Id");
            CreateIndex("dbo.Modeloes", "Carro_Id");
            AddForeignKey("dbo.Modeloes", "Carro_Id", "dbo.Carroes", "Id");
        }
    }
}
