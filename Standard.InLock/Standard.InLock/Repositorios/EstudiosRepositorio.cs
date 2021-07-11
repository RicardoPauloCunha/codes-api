using Standard.InLock.Domains;
using Standard.InLock.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Standard.InLock.Repositorios
{
    public class EstudiosRepositorio : IEstudiosRepositorio
    {
        readonly string _connectionString = "connection-string";

        public List<EstudiosDomain> Listar()
        {
            string QuerySelect = "SELECT Id, Nome FROM Estudios";

            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain
                        {
                            Id = Convert.ToInt32(sdr["Id"]),
                            Nome = sdr["Nome"].ToString()
                        };

                        estudios.Add(estudio);
                    }
                }
            }
            return estudios;
        }

        public List<EstudiosDomain> ListarEstudioJogo()
        {
            string QuerrySelect = "SELECT E.Id, E.Nome, J.Id, J.Nome FROM Estudios AS E " +
                "INNER JOIN Jogos AS J " +
                "ON E.Id = J.EstudioId";

            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerrySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain
                        {
                            Id = Convert.ToInt32(sdr["Id"]),
                            Nome = sdr["Nome"].ToString()
                        };

                        JogosDomain jogo = new JogosDomain
                        {
                            Id = Convert.ToInt32(sdr["Id"]),
                            Nome = sdr["Nome"].ToString(),
                            Descricao = sdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(sdr["Valor"]),
                            EstudioId = Convert.ToInt32(sdr["EstudioId"])
                        };

                        JogosRepositorio jogosRep = new JogosRepositorio();
                        jogosRep.ListarJogDoEstudio(estudio.Id);

                        estudios.Add(estudio);
                    }
                }
            }
            return estudios;
        }
    }
}
