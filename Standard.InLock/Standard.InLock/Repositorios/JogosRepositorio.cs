using Standard.InLock.Domains;
using Standard.InLock.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Standard.InLock.Repositorios
{
    public class JogosRepositorio : IJogosRepositorio
    {
        readonly string _connectionString = "connection-string";

        public void Cadastrar(JogosDomain jogo)
        {
            string QueryInsert = "INSERT INTO Jogos(NomeJogo, Descricao, DataLancamento, Valor, EstudioId) " +
                "VALUES (@Nome, @Descricao, @DataLancamento, @Valor, @EstudioId)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);
                    cmd.Parameters.AddWithValue("@EstudioId", jogo.EstudioId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> Listar()
        {
            string QuerySelect = "SELECT J.Id, J.Nome, J.Descricao, J.DataLancamento, J.Valor, J.EstudioId, E.Id, E.Nome FROM Jogos AS J " +
                "INNER JOIN Estudios AS E " +
                "ON J.EstudioId = E.Id";

            List<JogosDomain> jogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain
                        {
                            Id = Convert.ToInt32(sdr["Id"]),
                            Nome = sdr["Nome"].ToString(),
                            Descricao = sdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(sdr["Valor"]),
                            Estudio = new EstudiosDomain
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Nome = sdr["Nome"].ToString()
                            }
                        };

                        jogos.Add(jogo);
                    }
                }
            }

            return jogos;
        }

        public List<JogosDomain> ListarJogDoEstudio(int estudioId)
        {
            string QuerySelect = "SELECT Id, Nome, Descricao, DataLancamento, Valor, EstudioId FROM Jogos WHERE EstudioId = @EstudioId;";

            List<JogosDomain> jogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@EstudioId", estudioId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain
                        {
                            Id = Convert.ToInt32(sdr["Id"]),
                            Nome = sdr["Nome"].ToString(),
                            Descricao = sdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(sdr["Valor"]),
                            EstudioId = Convert.ToInt32(sdr["EstudioId"])
                        };

                        jogos.Add(jogo);
                    }
                }
            }
            return jogos;
        }
    }
}
