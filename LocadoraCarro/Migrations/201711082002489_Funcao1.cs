namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Funcao1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Funcaos", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Funcaos", "Nome", c => c.String());
        }
    }
}
