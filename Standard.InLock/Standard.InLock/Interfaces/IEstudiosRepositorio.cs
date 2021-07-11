using Standard.InLock.Domains;
using System.Collections.Generic;

namespace Standard.InLock.Interfaces
{
    interface IEstudiosRepositorio
    {
        List<EstudiosDomain> Listar();
        List<EstudiosDomain> ListarEstudioJogo();
    }
}
