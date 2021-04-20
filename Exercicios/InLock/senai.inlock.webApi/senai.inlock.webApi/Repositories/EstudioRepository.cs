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

        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<EstudioDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
