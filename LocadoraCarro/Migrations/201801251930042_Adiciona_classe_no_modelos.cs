namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adiciona_classe_no_modelos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modeloes", "Classe_Id", c => c.Int());
            CreateIndex("dbo.Modeloes", "Classe_Id");
            AddForeignKey("dbo.Modeloes", "Classe_Id", "dbo.Classes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modeloes", "Classe_Id", "dbo.Classes");
            DropIndex("dbo.Modeloes", new[] { "Classe_Id" });
            DropColumn("dbo.Modeloes", "Classe_Id");
        }
    }
}
