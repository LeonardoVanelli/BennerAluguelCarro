using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class Carro
    {
        public int Id { get; set; }

        public string Placa { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public Classe Classe { get; set; }

        public string Descricao { get; set; }

        public double PrecoHora { get; set; }

    }
}