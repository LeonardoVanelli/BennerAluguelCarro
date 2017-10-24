namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carros1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "Carro_Id", "dbo.Carroes");
            DropIndex("dbo.Classes", new[] { "Carro_Id" });
            CreateTable(
                "dbo.ClasseCarroes",
                c => new
                    {
                        Classe_Id = c.Int(nullable: false),
                        Carro_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Classe_Id, t.Carro_Id })
                .ForeignKey("dbo.Classes", t => t.Classe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carroes", t => t.Carro_Id, cascadeDelete: true)
                .Index(t => t.Classe_Id)
                .Index(t => t.Carro_Id);
            
            DropColumn("dbo.Classes", "Carro_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "Carro_Id", c => c.Int());
            DropForeignKey("dbo.ClasseCarroes", "Carro_Id", "dbo.Carroes");
            DropForeignKey("dbo.ClasseCarroes", "Classe_Id", "dbo.Classes");
            DropIndex("dbo.ClasseCarroes", new[] { "Carro_Id" });
            DropIndex("dbo.ClasseCarroes", new[] { "Classe_Id" });
            DropTable("dbo.ClasseCarroes");
            CreateIndex("dbo.Classes", "Carro_Id");
            AddForeignKey("dbo.Classes", "Carro_Id", "dbo.Carroes", "Id");
        }
    }
}
