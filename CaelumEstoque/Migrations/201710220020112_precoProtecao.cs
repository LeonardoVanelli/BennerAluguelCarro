namespace CaelumEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class precoProtecao : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Protecaos", "Preco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Protecaos", "Preco", c => c.Single(nullable: false));
        }
    }
}
