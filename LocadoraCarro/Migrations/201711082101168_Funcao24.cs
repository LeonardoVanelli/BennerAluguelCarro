namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Funcao24 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Funcaos");
        }
    }
}
