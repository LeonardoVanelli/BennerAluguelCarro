using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Funcao Funcao { get; set; }
        public int FuncaoId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}