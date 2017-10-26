using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public Modelo Modelo { get; set; }
        public int? ModeloId { get; set; }
        public Classe Classe { get; set; }
        public int? ClasseId { get; set; }
        public string Descricao { get; set; }
        public double PrecoDia { get; set; }
        public int QtdDisponivel { get; set; }
    }
}