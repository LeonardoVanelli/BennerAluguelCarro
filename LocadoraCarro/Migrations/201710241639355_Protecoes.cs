namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Protecoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Protecaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        PrecoDia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Protecaos");
        }
    }
}
