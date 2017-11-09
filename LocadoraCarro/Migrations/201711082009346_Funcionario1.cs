namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Funcionario1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionarios", "Nome", c => c.String());
            AddColumn("dbo.Funcionarios", "DataNascimento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Funcionarios", "FuncaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Funcionarios", "Login", c => c.String());
            AddColumn("dbo.Funcionarios", "Senha", c => c.String());
            CreateIndex("dbo.Funcionarios", "FuncaoId");
            AddForeignKey("dbo.Funcionarios", "FuncaoId", "dbo.Funcaos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionarios", "FuncaoId", "dbo.Funcaos");
            DropIndex("dbo.Funcionarios", new[] { "FuncaoId" });
            DropColumn("dbo.Funcionarios", "Senha");
            DropColumn("dbo.Funcionarios", "Login");
            DropColumn("dbo.Funcionarios", "FuncaoId");
            DropColumn("dbo.Funcionarios", "DataNascimento");
            DropColumn("dbo.Funcionarios", "Nome");
        }
    }
}
