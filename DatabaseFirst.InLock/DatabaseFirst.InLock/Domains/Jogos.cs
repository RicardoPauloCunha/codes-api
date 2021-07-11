using System;

namespace DatabaseFirst.InLock.Domains
{
    public partial class Jogos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public int? EstudioId { get; set; }
        public Estudios Estudio { get; set; }
    }
}
