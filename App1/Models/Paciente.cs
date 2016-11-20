using System.Collections.Generic;

namespace WsReceita.Models
{
    public class Paciente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public List<Receita> Receitas { get; set; }
    }
}