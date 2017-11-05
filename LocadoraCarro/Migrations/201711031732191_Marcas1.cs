namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Marcas1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas");
            DropIndex("dbo.Modeloes", new[] { "MarcaId" });
            AlterColumn("dbo.Modeloes", "MarcaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Modeloes", "MarcaId");
            AddForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas");
            DropIndex("dbo.Modeloes", new[] { "MarcaId" });
            AlterColumn("dbo.Modeloes", "MarcaId", c => c.Int());
            CreateIndex("dbo.Modeloes", "MarcaId");
            AddForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas", "Id");
        }
    }
}
