using System.Collections.Generic;

namespace WsReceita.Models
{
    public class Medico
    {
        public string Crm { get; set; }
        public string Nome { get; set; }
        public List<Receita> Receitas { get; set; }
        public Usuario Usuario { get; set; }
    }
}