using DatabaseFirst.Senatur.Domains;
using System.Collections.Generic;

namespace DatabaseFirst.Senatur.Interface
{
    interface IPacotesRepositorio
    {
        List<Pacotes> Listar();
        void Cadastrar(Pacotes pacote);
        void Alterar(Pacotes pacote);
    }
}
