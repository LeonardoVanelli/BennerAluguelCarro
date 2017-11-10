namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Funcionario4 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcaos", t => t.FuncaoId, cascadeDelete: true)
                .Index(t => t.FuncaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionarios", "FuncaoId", "dbo.Funcaos");
            DropIndex("dbo.Funcionarios", new[] { "FuncaoId" });
            DropTable("dbo.Funcionarios");
        }
    }
}
