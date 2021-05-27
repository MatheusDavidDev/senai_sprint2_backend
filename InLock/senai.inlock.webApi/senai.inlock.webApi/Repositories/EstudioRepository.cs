using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace senai.inlock.webApi_.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// conexao com o banco de dados
        /// </summary>
        private string stringConexao = "Data Source=MATHEUS-PC\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=190420";
        public void AtualizarIdCorpo(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdBody = "UPDATE Estudios SET nomeEstudio = @NOME WHERE idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", estudio.nomeEstudio);
                    cmd.Parameters.AddWithValue("@ID", estudio.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }  
            }
        }

        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idEstudio, nomeEstudio FROM Estudios WHERE idEstudio = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudioDomain estudioBuscado = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),

                            nomeEstudio = rdr["nomeEstudio"].ToString()
                        };

                        return estudioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Estudios(nomeEstudio) VALUES(@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.nomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
    }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Estudios WHERE idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand (queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idEstudio, nomeEstudio FROM Estudios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),

                            nomeEstudio = rdr[1].ToString()
                        };

                        listaEstudios.Add(estudio);

                    }
                }
            }

            return listaEstudios;

        }
    }
}
