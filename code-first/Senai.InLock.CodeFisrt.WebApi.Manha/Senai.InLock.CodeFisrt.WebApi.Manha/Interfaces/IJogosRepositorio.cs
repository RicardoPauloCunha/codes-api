using Senai.InLock.CodeFisrt.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFisrt.WebApi.Manha.Interfaces
{
    interface IJogosRepositorio
    {
        List<JogosDomain> Listar();

        void Cadastrar(JogosDomain jogo);

        void Remover(JogosDomain jogo);

        void Alterar(JogosDomain jogo);
    }
}
