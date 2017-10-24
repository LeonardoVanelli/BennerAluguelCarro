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
        public DbSet<Modelo> Modelos { get; set; }

        public LocadoraContext() : base("Server=(localdb)\\mssqllocaldb;Database=LocadoraCarroDB;Trusted_Connection=true;")
        {

        }
    }
}