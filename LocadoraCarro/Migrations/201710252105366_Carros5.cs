namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carros5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carroes", "QtdDisponivel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carroes", "QtdDisponivel");
        }
    }
}
