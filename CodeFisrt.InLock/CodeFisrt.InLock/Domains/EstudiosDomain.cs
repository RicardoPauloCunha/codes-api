using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFisrt.InLock.Domains
{
    [Table("Estudios")]
    public class EstudiosDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Nome", TypeName = "varchar(250)")]
        public string Nome { get; set; }

        public List<JogosDomain> Jogos{ get; set; }
    }
}
