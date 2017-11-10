namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class funcao : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Funcaos", "Descricao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Funcaos", "Descricao", c => c.String());
        }
    }
}
