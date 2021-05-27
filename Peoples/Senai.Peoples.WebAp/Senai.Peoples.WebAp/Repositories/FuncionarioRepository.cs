using Senai.Peoples.WebAp.Domains;
using Senai.Peoples.WebAp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAp.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringConexao = "Data Source=MATHEUS-PC\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=190420";
        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE funcionarios SET nome = @Nome, sobrenome = @Sobrenome, dataNascimento = @DataNascimento WHERE idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.dataNascimento);
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idFuncionario, nome, sobrenome, dataNascimento FROM funcionarios WHERE idFuncionario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),

                            nome = rdr["nome"].ToString(),

                            sobrenome = rdr["sobrenome"].ToString(),

                            dataNascimento = Convert.ToDateTime(rdr["dataNascimento"])
                        };

                        return funcionarioBuscado;
                    }

                    return null;
                }

            }
        }

        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO funcionarios(nome, sobrenome, dataNascimento) VALUES (@Nome, @Sobrenome, @Data)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    

                    cmd.Parameters.AddWithValue("@Nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", novoFuncionario.sobrenome);
                    cmd.Parameters.AddWithValue("@Data", novoFuncionario.dataNascimento);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM funcionarios WHERE idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idFuncionario, nome, sobrenome, dataNascimento FROM funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),

                            nome          = rdr["nome"].ToString(),

                            sobrenome     = rdr["sobrenome"].ToString(),

                            dataNascimento = Convert.ToDateTime(rdr["dataNascimento"])
                        };

                        listaFuncionarios.Add(funcionario);
                    }
                }
            }

            return listaFuncionarios;
        }
    }
}
