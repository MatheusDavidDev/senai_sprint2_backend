using HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS_WebApi.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        ///  Lista todos os personagens
        /// </summary>
        /// <returns> Uma lista de personagens</returns>
        List<Personagen> Listar();

        /// <summary>
        /// Busca um personagem pelo id
        /// </summary>
        /// <param name="id"> id do Personagem buscado </param>
        /// <returns> personagem buscado</returns>
        Personagen BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem que sera cadastrado</param>
        void Cadastrar(Personagen novoPersonagem);

        /// <summary>
        /// Atualiza um personagem 
        /// </summary>
        /// <param name="id"> ID do Personagem que sera atualizado</param>
        /// <param name="personagemAtualizada">Objeto personagem com as novas informacoes</param>
        void Atualizar(int id, Personagen personagemAtualizada);

        /// <summary>
        /// Deleta um personagem
        /// </summary>
        /// <param name="id">id do personagem que sera deletado </param>
        void Deletar(int id);


        List<Personagen> ListarUsuarios();
    }
}
