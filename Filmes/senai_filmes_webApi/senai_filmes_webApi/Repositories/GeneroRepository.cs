using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio dos generos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados que recebe os parametros
        /// Data Source = Nome do servidor
        /// Initial catalog = Nome do branco de dados
        /// user Id=sa; pwd=190420 = Faz a autenticacao com o usuario do sistema
        /// integrated security=true = faz a autenticacao com o usuario do sistema (Windows)
        /// </summary>
        private string stringConexao = "Data Source=MATHEUS-PC\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=190420";
        
        /// <summary>
        /// Atualiza um genero passando o id pelo corpo
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informacoes</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateBody = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                // Declara o SqlCommand cmd passando a query que sera executada e a conexao con como parametro
                using (SqlCommand cmd = new SqlCommand(queryUpdateBody,con))
                {
                    // Passa os valores para os parametros
                    cmd.Parameters.AddWithValue("@ID", genero.idGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    // Abre a conexao com o banco de dados
                    con.Open();

                    // Executa o comando 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um genero passando o id pelo recurto (URL)
        /// </summary>
        /// <param name="id">id genero que sera atualizado</param>
        /// <param name="genero"> Objeto genero com as novas informacoes</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                // Declara o SqlCommand cmd passando a query que sera executada e a conexao con como parametro
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa os valores para os parametros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    // Abre a conexao com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///  Busca um genero atraves do seu id
        /// </summary>
        /// <param name="id">id do genero que sera buscado</param>
        /// <returns>Um genero buscado ou null</returns>
        public GeneroDomain BuscasPorId(int id)
        {
            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
               // Declara a query a ser executada
                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGenero = @ID";

                // Abre conexao com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            // Atribui a propriedade idGenero o valor da coluna "idGenero" da tabela de banco de dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),

                            // Atrbui a propriedade nome o valor da coluna "Nome" da tabela de banco de dados
                            Nome     = rdr["Nome"].ToString()
                        };

                        // Retorna o generoBuscado com os dados obtidos
                        return generoBuscado; 

                    }

                    // Se nao, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastraum novo genero 
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com as informacoes que serao cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a SqlConnection con passando a string conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                                      // INSERT INTO Generos(Nome) VALUES('Aventura');
                                      // INSERT INTO Generos(Nome) VALUES('Joana D'Arc');
                                      // INSERT INTO Generos(Nome) VALUES('')DROP TABLE Filmes--');
                // string queryInsert = "INSERT INTO Generos(Nome) VALUES('" + novoGenero.Nome + "')";
                // Nao usar dessa forma pois pode causar o efeito Joana D'Arc
                // Alem de permitir SQL Injection
                // Por exemplo
                // "nome" : "')DROP TABLE Filmes--"
                // Ao tentar cadastrar o comando acima, ira deletar a tabela filmes do banco de dados

                string queryInsert = "INSERT INTO Generos(Nome) VALUES(@Nome)";

                // Declara o SqlCommand cmd passando a query que sera executada a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    // Abre a conexao com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um genero atraves do seu id
        /// </summary>
        /// <param name="id"> id do genero que sera deletado</param>
        public void Deletar(int id)
        {
            // Declara a SqlConnection con passando a strig de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))

            {   
                // Declara o SqlCommand passando a query que sera executada e a conexao como parametros
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no metodo como o valor do parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexao com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista listaGeneros onde serao armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection con passando a string conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrucao a ser executada
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

                //Abre a conexao com o banco de dados
                con.Open();

                // Declara o SqlDataReades rdr para percorrer a tabela banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laco se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto genero do time GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribuia propriedade idGenero o valor da primeira coluna da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),

                            // Atribui a propriedade Nome o valor da segunda coluna da tabela do banco de dados
                            Nome = rdr[1].ToString()
                        };

                        // Adiciona o objeto genero a lista listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            }

            //Retorna a lista generos
            return listaGeneros;
        }

    }
}
