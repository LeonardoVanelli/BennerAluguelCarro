namespace CaelumEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carro : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoriaDoProdutoes", newName: "Classes");
            DropForeignKey("dbo.Produtoes", "CategoriaId", "dbo.CategoriaDoProdutoes");
            DropIndex("dbo.Produtoes", new[] { "CategoriaId" });
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        Modelo = c.String(),
                        Marca = c.String(),
                        Descricao = c.String(),
                        PrecoHora = c.Double(nullable: false),
                        Classe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Classe_Id)
                .Index(t => t.Classe_Id);
            
            DropTable("dbo.Produtoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Single(nullable: false),
                        CategoriaId = c.Int(),
                        Descricao = c.String(),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Carroes", "Classe_Id", "dbo.Classes");
            DropIndex("dbo.Carroes", new[] { "Classe_Id" });
            DropTable("dbo.Carroes");
            CreateIndex("dbo.Produtoes", "CategoriaId");
            AddForeignKey("dbo.Produtoes", "CategoriaId", "dbo.CategoriaDoProdutoes", "Id");
            RenameTable(name: "dbo.Classes", newName: "CategoriaDoProdutoes");
        }
    }
}
