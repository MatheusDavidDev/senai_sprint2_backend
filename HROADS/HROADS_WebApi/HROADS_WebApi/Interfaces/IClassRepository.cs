using HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS_WebApi.Interfaces
{
    interface IClassRepository
    {
        /// <summary>
        ///  Lista todas as classes
        /// </summary>
        /// <returns> Uma lista de classes</returns>
        List<Class> Listar();

        /// <summary>
        /// Busca uma classe pelo id
        /// </summary>
        /// <param name="id"> id da classe buscada </param>
        /// <returns> classe buscada</returns>
        Class BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que sera cadastrada</param>
        void Cadastrar(Class novaClasse);

        /// <summary>
        /// Atualiza uma classe 
        /// </summary>
        /// <param name="id"> ID da classe que sera atualizado</param>
        /// <param name="classeAtualizada">Objeto classe com as novas informacoes</param>
        void Atualizar(int id, Class classeAtualizada);

        /// <summary>
        /// Deleta uma classe
        /// </summary>
        /// <param name="id">id da classe que sera deletada</param>
        void Deletar(int id);

        List<Class> ListarPersonagens();


    }
}
