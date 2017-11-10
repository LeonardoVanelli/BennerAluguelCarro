namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Marca : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Modeloes", "Marca_Id", c => c.Int());
            CreateIndex("dbo.Modeloes", "Marca_Id");
            AddForeignKey("dbo.Modeloes", "Marca_Id", "dbo.Marcas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modeloes", "Marca_Id", "dbo.Marcas");
            DropIndex("dbo.Modeloes", new[] { "Marca_Id" });
            DropColumn("dbo.Modeloes", "Marca_Id");
            DropTable("dbo.Marcas");
        }
    }
}
