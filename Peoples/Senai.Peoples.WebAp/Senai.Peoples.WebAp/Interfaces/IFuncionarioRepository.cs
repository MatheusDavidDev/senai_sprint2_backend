using Senai.Peoples.WebAp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAp.Interfaces
{
    interface IFuncionarioRepository
    {
        /// <summary>
        /// Me mostra todos os funcionarios do sistema
        /// </summary>
        /// <returns>lista de funcionarios</returns>
        List<FuncionarioDomain> ListarTodos();

        /// <summary>
        /// Busca um funcionario pelo id
        /// </summary>
        /// <param name="id"> id do usuario buscado</param>
        /// <returns>um objeto funcionarioDomain que foi buscado</returns>
        FuncionarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo funcionario
        /// </summary>
        /// <param name="novoFuncionario">Objeto funcionario com as informacoes do novo funcionario</param>
        void Cadastrar(FuncionarioDomain novoFuncionario);

        /// <summary>
        /// Atualiza as informacoes do funcionario
        /// </summary>
        /// <param name="id">id do funcionario que sera atualizado</param>
        /// <param name="funcionario"> Objeto funciorario com as novas informacoes</param>
        void AtualizarIdUrl(int id, FuncionarioDomain funcionario);
        
        /// <summary>
        /// Deleta um funcionario
        /// </summary>
        /// <param name="id">id do funcionaro que sera deletado</param>
        void deletar(int id);
    }
}
