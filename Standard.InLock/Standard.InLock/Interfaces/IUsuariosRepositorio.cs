using Standard.InLock.Domains;

namespace Standard.InLock.Interfaces
{
    interface IUsuariosRepositorio
    {
        UsuariosDomain BuscarUsuario(string email, string senha);
    }
}
