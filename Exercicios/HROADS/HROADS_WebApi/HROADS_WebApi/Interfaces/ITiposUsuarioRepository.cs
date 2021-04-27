using HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS_WebApi.Interfaces
{
    interface ITiposUsuarioRepository
    {
        /// <summary>
        ///  Lista todos os TiposUsuario
        /// </summary>
        /// <returns> Uma lista de TiposUsuario</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Busca um TiposUsuario pelo id
        /// </summary>
        /// <param name="id"> id do TiposUsuario buscado </param>
        /// <returns> TiposUsuario buscado</returns>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo TiposUsuario
        /// </summary>
        /// <param name="novoTipos">Objeto novoTiposUsuario que sera cadastrado</param>
        void Cadastrar(TiposUsuario novoTipos);

        /// <summary>
        /// Atualiza um TiposUsuario
        /// </summary>
        /// <param name="id"> ID do TiposUsuario que sera atualizado</param>
        /// <param name="tiposAtualizado">Objeto TiposUsuario com as novas informacoes</param>
        void Atualizar(int id, TiposUsuario tiposAtualizado);

        /// <summary>
        /// Deleta um TiposUsuario
        /// </summary>
        /// <param name="id">id do TiposUsuario que sera deletado </param>
        void Deletar(int id);

        List<TiposUsuario> ListarUsuarios();
    }
}
