using HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS_WebApi.Interfaces
{
    interface ITiposDeHabilidadesRepository
    {
        /// <summary>
        ///  Lista todos os TipoDeHabilidade
        /// </summary>
        /// <returns> Uma lista de TiposDeHabilidade</returns>
        List<TiposDeHabilidade> Listar();

        /// <summary>
        /// Busca um TipoDeHabilidade pelo id
        /// </summary>
        /// <param name="id"> id do TipoDeHabilidade buscado </param>
        /// <returns> TipoDeHabilidade buscado</returns>
        TiposDeHabilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo TipoDeHabilidade
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipoDeHabilidade que sera cadastrado</param>
        void Cadastrar(TiposDeHabilidade novoTipo);

        /// <summary>
        /// Atualiza um TipoDeHabilidade
        /// </summary>
        /// <param name="id"> ID do TipoDeHabilidade que sera atualizado</param>
        /// <param name="tipoAtualizado">Objeto TipoDeHabilidade com as novas informacoes</param>
        void Atualizar(int id, TiposDeHabilidade tipoAtualizado);

        /// <summary>
        /// Deleta um TipoDeHabilidade
        /// </summary>
        /// <param name="id">id do TipoDeHabilidade que sera deletado </param>
        void Deletar(int id);

        List<TiposDeHabilidade> ListarHabilidades();
    }
}
