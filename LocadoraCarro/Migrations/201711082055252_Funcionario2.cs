namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Funcionario2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Funcionarios", "FuncaoId", "dbo.Funcaos");
            DropIndex("dbo.Funcionarios", new[] { "FuncaoId" });
            DropTable("dbo.Funcionarios");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Funcionarios", "FuncaoId");
            AddForeignKey("dbo.Funcionarios", "FuncaoId", "dbo.Funcaos", "Id", cascadeDelete: true);
        }
    }
}
