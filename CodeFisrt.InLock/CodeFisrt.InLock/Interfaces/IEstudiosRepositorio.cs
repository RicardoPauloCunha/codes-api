using CodeFisrt.InLock.Domains;
using System.Collections.Generic;

namespace CodeFisrt.InLock.Interfaces
{
    interface IEstudiosRepositorio
    {
        List<EstudiosDomain> Listar();
        void Cadastrar(EstudiosDomain estudio);
        void Alterar(EstudiosDomain estudio);
        void Deletar(EstudiosDomain estudio);
    }
}
