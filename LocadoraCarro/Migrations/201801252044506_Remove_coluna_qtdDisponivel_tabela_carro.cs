namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_coluna_qtdDisponivel_tabela_carro : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carroes", "QtdDisponivel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carroes", "QtdDisponivel", c => c.Int(nullable: false));
        }
    }
}
