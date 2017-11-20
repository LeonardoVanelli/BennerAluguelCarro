using LocadoraCarro.DAO;
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
        public virtual Modelo Modelo { get; set; }
        public int ModeloId { get; set; }
        public virtual Classe Classe { get; set; }
        public int ClasseId { get; set; }
        public string Descricao { get; set; }
        public double PrecoDia { get; set; }
        public int QtdDisponivel { get; set; }
        public string Imagem { get; set; }

        public void Reserva()
        {
            this.QtdDisponivel--;
        }

        public void Libera()
        {
            this.QtdDisponivel++;
        }
    }
}