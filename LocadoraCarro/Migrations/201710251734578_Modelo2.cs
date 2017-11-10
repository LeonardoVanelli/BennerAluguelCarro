namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelo2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modeloes", "Marca_Id", "dbo.Marcas");
            DropIndex("dbo.Modeloes", new[] { "Marca_Id" });
            RenameColumn(table: "dbo.Modeloes", name: "Marca_Id", newName: "MarcaId");
            AlterColumn("dbo.Modeloes", "MarcaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Modeloes", "MarcaId");
            AddForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas");
            DropIndex("dbo.Modeloes", new[] { "MarcaId" });
            AlterColumn("dbo.Modeloes", "MarcaId", c => c.Int());
            RenameColumn(table: "dbo.Modeloes", name: "MarcaId", newName: "Marca_Id");
            CreateIndex("dbo.Modeloes", "Marca_Id");
            AddForeignKey("dbo.Modeloes", "Marca_Id", "dbo.Marcas", "Id");
        }
    }
}
