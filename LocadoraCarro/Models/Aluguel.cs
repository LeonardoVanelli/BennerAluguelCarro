using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.Models
{
    public class Aluguel
    {
        public int Id { get; set; }
        public DateTime DataHoraRetirada { get; set; }
        public DateTime DataHoraDevolucao { get; set; }
        public Cliente Cliente { get; set; }
        public Carro Carro { get; set; }
        public Protecao Protecao { get; set; }
    }
}