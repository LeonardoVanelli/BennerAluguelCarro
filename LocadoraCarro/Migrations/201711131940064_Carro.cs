namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carroes", "Imagem", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carroes", "Imagem");
        }
    }
}
