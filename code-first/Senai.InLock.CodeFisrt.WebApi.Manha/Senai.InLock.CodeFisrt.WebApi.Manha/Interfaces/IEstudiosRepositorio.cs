using Senai.InLock.CodeFisrt.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFisrt.WebApi.Manha.Interfaces
{
    interface IEstudiosRepositorio
    {
        List<EstudiosDomain> Listar();

        void Cadastrar(EstudiosDomain estudio);

        void Alterar(EstudiosDomain estudio);

        void Deletar(EstudiosDomain estudio);
    }
}
