namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carros6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Carroes", name: "Classe_Id", newName: "ClasseId");
            RenameColumn(table: "dbo.Carroes", name: "Modelo_Id", newName: "ModeloId");
            RenameIndex(table: "dbo.Carroes", name: "IX_Modelo_Id", newName: "IX_ModeloId");
            RenameIndex(table: "dbo.Carroes", name: "IX_Classe_Id", newName: "IX_ClasseId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Carroes", name: "IX_ClasseId", newName: "IX_Classe_Id");
            RenameIndex(table: "dbo.Carroes", name: "IX_ModeloId", newName: "IX_Modelo_Id");
            RenameColumn(table: "dbo.Carroes", name: "ModeloId", newName: "Modelo_Id");
            RenameColumn(table: "dbo.Carroes", name: "ClasseId", newName: "Classe_Id");
        }
    }
}
