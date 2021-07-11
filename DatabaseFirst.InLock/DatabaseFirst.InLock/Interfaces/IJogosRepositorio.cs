using DatabaseFirst.InLock.Domains;
using System.Collections.Generic;

namespace DatabaseFirst.InLock.Interfaces
{
    interface IJogosRepositorio
    {
        List<Jogos> Listar();
        List<Jogos> ListarJogosEstudios();
        void Cadastrar(Jogos jogo);
        void Remover(Jogos jogo);
        void Alterar(Jogos jogo);
    }
}
