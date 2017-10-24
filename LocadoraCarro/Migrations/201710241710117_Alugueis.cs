namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alugueis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluguels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataHoraRetirada = c.DateTime(nullable: false),
                        DataHoraDevolucao = c.DateTime(nullable: false),
                        Carro_Id = c.Int(),
                        Cliente_Id = c.Int(),
                        Protecao_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carroes", t => t.Carro_Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .ForeignKey("dbo.Protecaos", t => t.Protecao_Id)
                .Index(t => t.Carro_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Protecao_Id);
           
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
            
            DropForeignKey("dbo.Aluguels", "Protecao_Id", "dbo.Protecaos");
            DropForeignKey("dbo.Aluguels", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Aluguels", "Carro_Id", "dbo.Carroes");
            DropIndex("dbo.Aluguels", new[] { "Protecao_Id" });
            DropIndex("dbo.Aluguels", new[] { "Cliente_Id" });
            DropIndex("dbo.Aluguels", new[] { "Carro_Id" });
            DropTable("dbo.Aluguels");
        }
    }
}
