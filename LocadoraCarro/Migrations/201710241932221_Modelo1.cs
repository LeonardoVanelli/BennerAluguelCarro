namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modeloes", "Descricao", c => c.String());
            AlterColumn("dbo.Modeloes", "Nome", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modeloes", "Nome", c => c.String());
            DropColumn("dbo.Modeloes", "Descricao");
        }
    }
}
