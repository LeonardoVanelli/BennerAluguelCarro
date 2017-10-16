using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public String Placa { get; set; }

        public float PrecoHora { get; set; }

        public CategoriaDoProduto Classe { get; set; }

        public String Modelo { get; set; }

        public String Marca { get; set; }
    }
}