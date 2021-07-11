using System.Collections.Generic;

namespace DatabaseFirst.InLock.Domains
{
    public partial class Estudios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Jogos> Jogos { get; set; }

        public Estudios()
        {
            Jogos = new HashSet<Jogos>();
        }
    }
}
