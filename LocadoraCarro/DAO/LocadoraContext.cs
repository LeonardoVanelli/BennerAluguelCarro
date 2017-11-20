using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LocadoraCarro.DAO
{
    public class LocadoraContext : DbContext
    {
        public DbSet<Modelo>      Modelos { get; set; }
        public DbSet<Marca>       Marcas { get; set; }
        public DbSet<Classe>      Classes { get; set; }
        public DbSet<Carro>       Carros { get; set; }
        public DbSet<Cliente>     Clientes { get; set; }
        public DbSet<Protecao>    Protecoes { get; set; }
        public DbSet<Aluguel>     Alugueis { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Funcao>      Funcaos { get; set; }
        public DbSet<Status>      Statuos { get; set; }

        public LocadoraContext() : base("Server=(localdb)\\mssqllocaldb;Database=LocadoraCarroDB;Trusted_Connection=true;")
        {

        }
    }
}