namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Classe_carro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carroes", "ClasseId", "dbo.Classes");
            DropIndex("dbo.Carroes", new[] { "ClasseId" });
            DropColumn("dbo.Carroes", "ClasseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carroes", "ClasseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carroes", "ClasseId");
            AddForeignKey("dbo.Carroes", "ClasseId", "dbo.Classes", "Id", cascadeDelete: true);
        }
    }
}
