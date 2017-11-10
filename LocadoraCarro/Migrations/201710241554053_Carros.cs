namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        Descricao = c.String(),
                        PrecoDia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Classes", "Carro_Id", c => c.Int());
            AddColumn("dbo.Modeloes", "Carro_Id", c => c.Int());
            CreateIndex("dbo.Classes", "Carro_Id");
            CreateIndex("dbo.Modeloes", "Carro_Id");
            AddForeignKey("dbo.Classes", "Carro_Id", "dbo.Carroes", "Id");
            AddForeignKey("dbo.Modeloes", "Carro_Id", "dbo.Carroes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modeloes", "Carro_Id", "dbo.Carroes");
            DropForeignKey("dbo.Classes", "Carro_Id", "dbo.Carroes");
            DropIndex("dbo.Modeloes", new[] { "Carro_Id" });
            DropIndex("dbo.Classes", new[] { "Carro_Id" });
            DropColumn("dbo.Modeloes", "Carro_Id");
            DropColumn("dbo.Classes", "Carro_Id");
            DropTable("dbo.Carroes");
        }
    }
}
