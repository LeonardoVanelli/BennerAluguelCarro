namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClasseId_tabela_Modelo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Modeloes", name: "Classe_Id", newName: "ClasseId");
            RenameIndex(table: "dbo.Modeloes", name: "IX_Classe_Id", newName: "IX_ClasseId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Modeloes", name: "IX_ClasseId", newName: "IX_Classe_Id");
            RenameColumn(table: "dbo.Modeloes", name: "ClasseId", newName: "Classe_Id");
        }
    }
}
