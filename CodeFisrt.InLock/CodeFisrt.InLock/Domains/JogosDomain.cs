using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFisrt.InLock.Domains
{
    [Table("Jogos")]
    public class JogosDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar(250)")]
        public string Nome { get; set; }

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
