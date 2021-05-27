using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Retorna todos os estudios
        /// </summary>
        /// <returns>Lista de estudios</returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Busca estudio pelo id
        /// </summary>
        /// <param name="id">id do estudio buscado</param>
        /// <returns>Um objeto do tipo EstudioDomain que foi buscado</returns>
        EstudioDomain BuscarPorId(int id);

        /// <summary>
        ///  Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que sera cadastrado</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Atualiza um estudio que existe passando o id pelo corpo da requisicao
        /// </summary>
        /// <param name="estudio">Objeto genero com as novas informacoes</param>
        void AtualizarIdCorpo(EstudioDomain estudio);

        /// <summary>
        ///  Deleta um Estudio
        /// </summary>
        /// <param name="id">id do estudio que sera deletado</param>
        void Deletar(int id);

        
    }
}
