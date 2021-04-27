using HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS_WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        ///  Lista todos os Usuario
        /// </summary>
        /// <returns> Uma lista de Usuario</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um Usuario pelo id
        /// </summary>
        /// <param name="id"> id do Usuario buscado </param>
        /// <returns> Usuario buscado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que sera cadastrado</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um Usuario
        /// </summary>
        /// <param name="id"> ID do Usuario que sera atualizado</param>
        /// <param name="usuarioAtualizado">Objeto Usuario com as novas informacoes</param>
        void Atualizar(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um Usuario
        /// </summary>
        /// <param name="id">id do Usuario que sera deletado </param>
        void Deletar(int id);

        Usuario Login(string email, string senha);
    }
}
