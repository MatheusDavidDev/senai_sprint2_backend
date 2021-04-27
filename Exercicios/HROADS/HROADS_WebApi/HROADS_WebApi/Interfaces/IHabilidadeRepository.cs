using HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS_WebApi.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        ///  Lista todas as habilidades
        /// </summary>
        /// <returns> Uma lista de habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca uma habilidade pelo id
        /// </summary>
        /// <param name="id"> id da habilidade buscada </param>
        /// <returns> classe buscada</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novahabilidade que sera cadastrada</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma habilidade
        /// </summary>
        /// <param name="id"> ID da habilidade que sera atualizado</param>
        /// <param name="habilidadeAtualizada">Objeto habilidade com as novas informacoes</param>
        void Atualizar(int id, Habilidade habilidadeAtualizada);

        /// <summary>
        /// Deleta uma habilidade
        /// </summary>
        /// <param name="id">id da habilidade que sera deletada</param>
        void Deletar(int id);

        
    }
}
