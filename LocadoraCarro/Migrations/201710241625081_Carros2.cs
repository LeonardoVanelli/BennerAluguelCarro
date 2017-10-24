namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carros2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClasseCarroes", "Classe_Id", "dbo.Classes");
            DropForeignKey("dbo.ClasseCarroes", "Carro_Id", "dbo.Carroes");
            DropIndex("dbo.ClasseCarroes", new[] { "Classe_Id" });
            DropIndex("dbo.ClasseCarroes", new[] { "Carro_Id" });
            AddColumn("dbo.Carroes", "Classe_Id", c => c.Int());
            CreateIndex("dbo.Carroes", "Classe_Id");
            AddForeignKey("dbo.Carroes", "Classe_Id", "dbo.Classes", "Id");
            DropTable("dbo.ClasseCarroes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClasseCarroes",
                c => new
                    {
                        Classe_Id = c.Int(nullable: false),
                        Carro_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Classe_Id, t.Carro_Id });
            
            DropForeignKey("dbo.Carroes", "Classe_Id", "dbo.Classes");
            DropIndex("dbo.Carroes", new[] { "Classe_Id" });
            DropColumn("dbo.Carroes", "Classe_Id");
            CreateIndex("dbo.ClasseCarroes", "Carro_Id");
            CreateIndex("dbo.ClasseCarroes", "Classe_Id");
            AddForeignKey("dbo.ClasseCarroes", "Carro_Id", "dbo.Carroes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClasseCarroes", "Classe_Id", "dbo.Classes", "Id", cascadeDelete: true);
        }
    }
}
