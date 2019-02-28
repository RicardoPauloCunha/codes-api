using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFisrt.WebApi.Manha.Domains
{
    [Table("Jogos")]
    public class JogosDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JogoId { get; set; }

        [Required]
        [Column(TypeName = "Varchar(250)")]
        public string NomeJogo { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required]
        public int EstudioId { get; set; }

        [ForeignKey("EstudioId")]
        public EstudiosDomain Estudio { get; set; }
    }
}
