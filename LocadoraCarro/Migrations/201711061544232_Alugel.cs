namespace LocadoraCarro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alugel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Aluguels", "Carro_Id", "dbo.Carroes");
            DropForeignKey("dbo.Aluguels", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Aluguels", "Protecao_Id", "dbo.Protecaos");
            DropForeignKey("dbo.Carroes", "ClasseId", "dbo.Classes");
            DropIndex("dbo.Aluguels", new[] { "Carro_Id" });
            DropIndex("dbo.Aluguels", new[] { "Cliente_Id" });
            DropIndex("dbo.Aluguels", new[] { "Protecao_Id" });
            DropIndex("dbo.Carroes", new[] { "ClasseId" });
            RenameColumn(table: "dbo.Aluguels", name: "Carro_Id", newName: "CarroId");
            RenameColumn(table: "dbo.Aluguels", name: "Cliente_Id", newName: "ClienteId");
            RenameColumn(table: "dbo.Aluguels", name: "Protecao_Id", newName: "ProtecaoId");
            AlterColumn("dbo.Aluguels", "CarroId", c => c.Int(nullable: false));
            AlterColumn("dbo.Aluguels", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Aluguels", "ProtecaoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Carroes", "ClasseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Aluguels", "ClienteId");
            CreateIndex("dbo.Aluguels", "CarroId");
            CreateIndex("dbo.Aluguels", "ProtecaoId");
            CreateIndex("dbo.Carroes", "ClasseId");
            AddForeignKey("dbo.Aluguels", "CarroId", "dbo.Carroes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Aluguels", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Aluguels", "ProtecaoId", "dbo.Protecaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carroes", "ClasseId", "dbo.Classes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carroes", "ClasseId", "dbo.Classes");
            DropForeignKey("dbo.Aluguels", "ProtecaoId", "dbo.Protecaos");
            DropForeignKey("dbo.Aluguels", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Aluguels", "CarroId", "dbo.Carroes");
            DropIndex("dbo.Carroes", new[] { "ClasseId" });
            DropIndex("dbo.Aluguels", new[] { "ProtecaoId" });
            DropIndex("dbo.Aluguels", new[] { "CarroId" });
            DropIndex("dbo.Aluguels", new[] { "ClienteId" });
            AlterColumn("dbo.Carroes", "ClasseId", c => c.Int());
            AlterColumn("dbo.Aluguels", "ProtecaoId", c => c.Int());
            AlterColumn("dbo.Aluguels", "ClienteId", c => c.Int());
            AlterColumn("dbo.Aluguels", "CarroId", c => c.Int());
            RenameColumn(table: "dbo.Aluguels", name: "ProtecaoId", newName: "Protecao_Id");
            RenameColumn(table: "dbo.Aluguels", name: "ClienteId", newName: "Cliente_Id");
            RenameColumn(table: "dbo.Aluguels", name: "CarroId", newName: "Carro_Id");
            CreateIndex("dbo.Carroes", "ClasseId");
            CreateIndex("dbo.Aluguels", "Protecao_Id");
            CreateIndex("dbo.Aluguels", "Cliente_Id");
            CreateIndex("dbo.Aluguels", "Carro_Id");
            AddForeignKey("dbo.Carroes", "ClasseId", "dbo.Classes", "Id");
            AddForeignKey("dbo.Aluguels", "Protecao_Id", "dbo.Protecaos", "Id");
            AddForeignKey("dbo.Aluguels", "Cliente_Id", "dbo.Clientes", "Id");
            AddForeignKey("dbo.Aluguels", "Carro_Id", "dbo.Carroes", "Id");
        }
    }
}
