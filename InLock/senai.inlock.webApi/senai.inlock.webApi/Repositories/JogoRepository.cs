using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=MATHEUS-PC\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=190420";

        public void AtualizaIdCorpo(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE Jogos SET idEstudio = @IDestudio, nomeJogo = @Nome, descricao = @Desc, dataLancamento = @Data, valor = @Valor WHERE idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@IDestudio", jogo.idEstudio);
                    cmd.Parameters.AddWithValue("@Nome", jogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@Desc", jogo.descricao);
                    cmd.Parameters.AddWithValue("@Data", jogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.valor);
                    cmd.Parameters.AddWithValue("@ID", jogo.idJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idJogo, nomeJogo, idEstudio, descricao, dataLancamento, valor FROM Jogos WHERE idJogo = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),

                            nomeJogo = rdr[1].ToString(),

                            idEstudio = Convert.ToInt32(rdr[2]),

                            descricao = rdr[3].ToString(),

                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),

                            valor = Convert.(rdr["valor"])
                        };
                    }
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
