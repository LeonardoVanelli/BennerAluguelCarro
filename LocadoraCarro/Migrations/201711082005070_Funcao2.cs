namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Funcao2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcaos", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Funcaos", "Nome");
        }
    }
}
