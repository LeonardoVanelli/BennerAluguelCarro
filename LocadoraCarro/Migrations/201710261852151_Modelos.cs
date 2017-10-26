namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas");
            DropIndex("dbo.Modeloes", new[] { "MarcaId" });
            RenameColumn(table: "dbo.Modeloes", name: "MarcaId", newName: "Marca_Id");
            AlterColumn("dbo.Modeloes", "Marca_Id", c => c.Int());
            CreateIndex("dbo.Modeloes", "Marca_Id");
            AddForeignKey("dbo.Modeloes", "Marca_Id", "dbo.Marcas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modeloes", "Marca_Id", "dbo.Marcas");
            DropIndex("dbo.Modeloes", new[] { "Marca_Id" });
            AlterColumn("dbo.Modeloes", "Marca_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Modeloes", name: "Marca_Id", newName: "MarcaId");
            CreateIndex("dbo.Modeloes", "MarcaId");
            AddForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas", "Id", cascadeDelete: true);
        }
    }
}
