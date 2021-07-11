using Standard.InLock.Domains;
using System.Collections.Generic;

namespace Standard.InLock.Interfaces
{
    interface IJogosRepositorio
    {
        void Cadastrar(JogosDomain jogo);
        List<JogosDomain> Listar();
        List<JogosDomain> ListarJogDoEstudio(int estudioId);
    }
}
