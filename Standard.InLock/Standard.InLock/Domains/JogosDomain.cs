using System;
using System.ComponentModel.DataAnnotations;

namespace Standard.InLock.Domains
{
    public class JogosDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Jogo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Descrição do Jogo")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a Data de Lançamento do Jogo")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Informe o Valor do Jogo")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Informe o Estúdio do Jogo")]
        public int EstudioId { get; set; }

        public EstudiosDomain Estudio { get; set; }
    }
}
