using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraCarro.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        [Required, StringLength(60)]
        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}