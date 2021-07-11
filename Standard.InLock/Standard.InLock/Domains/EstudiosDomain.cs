using System.ComponentModel.DataAnnotations;

namespace Standard.InLock.Domains
{
    public class EstudiosDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Estudio")]
        public string Nome { get; set; }
    }
}
