using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFisrt.WebApi.Manha.Domains
{
    [Table("Estudios")]
    public class EstudiosDomain
    {
        //chave primaria
        [Key]
        //gerar o id com auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstudioId { get; set; }


        //not null
        [Required]
        // varchar(250)
        [Column("NomeEstudio",TypeName = "varchar(250)")]
        public string EstudioNome { get; set; }

        public List<JogosDomain> Jogos{ get; set; }
    }
}
