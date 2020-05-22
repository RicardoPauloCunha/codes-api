using Senai.InLock.DatabaseFisrt.Solution.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.DatabaseFisrt.Solution.Interfaces
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
