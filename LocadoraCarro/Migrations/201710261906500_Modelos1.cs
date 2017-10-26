namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelos1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Modeloes", name: "Marca_Id", newName: "MarcaId");
            RenameIndex(table: "dbo.Modeloes", name: "IX_Marca_Id", newName: "IX_MarcaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Modeloes", name: "IX_MarcaId", newName: "IX_Marca_Id");
            RenameColumn(table: "dbo.Modeloes", name: "MarcaId", newName: "Marca_Id");
        }
    }
}
