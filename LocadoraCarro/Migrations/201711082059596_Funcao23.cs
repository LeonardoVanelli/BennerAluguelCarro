namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Funcao23 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Funcaos");
        }
        
        public override void Down()
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
    }
}
