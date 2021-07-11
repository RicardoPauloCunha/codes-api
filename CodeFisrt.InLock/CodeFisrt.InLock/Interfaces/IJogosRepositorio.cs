using CodeFisrt.InLock.Domains;
using System.Collections.Generic;

namespace CodeFisrt.InLock.Interfaces
{
    interface IJogosRepositorio
    {
        List<JogosDomain> Listar();
        void Cadastrar(JogosDomain jogo);
        void Remover(JogosDomain jogo);
        void Alterar(JogosDomain jogo);
    }
}
