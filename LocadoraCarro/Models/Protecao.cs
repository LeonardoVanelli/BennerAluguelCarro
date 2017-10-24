using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.Models
{
    public class Protecao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoDia { get; set; }
    }
}