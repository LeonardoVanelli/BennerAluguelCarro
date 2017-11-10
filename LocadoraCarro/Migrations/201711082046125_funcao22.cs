namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class funcao22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcaos", "Descricao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Funcaos", "Descricao");
        }
    }
}
