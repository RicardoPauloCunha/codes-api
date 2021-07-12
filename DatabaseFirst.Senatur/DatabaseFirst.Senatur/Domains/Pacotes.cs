using System;

namespace DatabaseFirst.Senatur.Domains
{
    public partial class Pacotes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataId { get; set; }
        public DateTime DataVolta { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public string NomeCidade { get; set; }
    }
}
