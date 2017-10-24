namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clientes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Login", c => c.String());
            AddColumn("dbo.Clientes", "Senha", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Senha");
            DropColumn("dbo.Clientes", "Login");
        }
    }
}
