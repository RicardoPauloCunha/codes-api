using Standard.InLock.Domains;
using Standard.InLock.Interfaces;
using System;
using System.Data.SqlClient;

namespace Standard.InLock.Repositorios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        readonly string _connectionString = "connection-string";

        public UsuariosDomain BuscarUsuario(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string QuerySelect = "SELECT U.Id, U.Email, U.Senha, U.TipoUsuario FROM Usuarios AS U WHERE U.Email = @Email AND U.Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        UsuariosDomain usuario = new UsuariosDomain();

                        while (sdr.Read())
                        {
                            usuario.Id = Convert.ToInt32(sdr["Id"]);
                            usuario.Email = sdr["Email"].ToString();
                            usuario.Senha = sdr["Senha"].ToString();
                            usuario.TipoUsuario = sdr["TipoUsuario"].ToString();
                        }
                        return usuario;
                    }
                }
                return null;
            }
        }
    }
}
