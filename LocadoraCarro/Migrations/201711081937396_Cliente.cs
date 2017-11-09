namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Funcionarios", "FuncaoId", "dbo.Funcaos");
            DropIndex("dbo.Funcionarios", new[] { "FuncaoId" });
            AddColumn("dbo.Clientes", "Telefone", c => c.String());
            DropColumn("dbo.Clientes", "Telefono");
            DropTable("dbo.Funcionarios");
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
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cpf = c.String(),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        FuncaoId = c.Int(nullable: false),
                        Login = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clientes", "Telefono", c => c.String());
            DropColumn("dbo.Clientes", "Telefone");
            CreateIndex("dbo.Funcionarios", "FuncaoId");
            AddForeignKey("dbo.Funcionarios", "FuncaoId", "dbo.Funcaos", "Id", cascadeDelete: true);
        }
    }
}
