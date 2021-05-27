using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRespository
    /// </summary>
    public interface IGeneroRepository
    {
        // TipoRetorno  NomeMetodo(TipoParametro parametro);

        /// <summary>
        /// Retornar todos os generos 
        /// </summary>
        /// <returns>Uma lista de generos</returns>

        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// Busca um genero atraves do seu id
        /// </summary>
        /// <param name="id">id do genero que sera buscado</param>
        /// <returns>Um objeto do tipo GeneroDomain que foi buscado</returns>
        GeneroDomain BuscasPorId(int id);

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto genero com as novas informacoes</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um genero existente passando o id pelo corpo da requisisao
        /// </summary>
        /// <param name="genero">Objeto genero que sera atualizado</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um genero existente passando o id pela url da requisicao
        /// </summary>
        /// <param name="id">id do genero que sera atualizado</param>
        /// <param name="genero">Objeto genero com as novas informacoes</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um genero
        /// </summary>
        /// <param name="id">id genero que sera deletado</param>
        void Deletar(int id);


    }
}
