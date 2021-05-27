using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Retorna todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Busca um jogo atraves do id
        /// </summary>
        /// <param name="id">id do jogo que sera buscado</param>
        /// <returns>Um objeto do tipo JogoDomain que foi buscado</returns>
        JogoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que sera cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Atualiza um jogo passando o id pele corpo
        /// </summary>
        /// <param name="jogo"></param>
        void AtualizaIdCorpo(JogoDomain jogo);

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">id do jogo que sera deletado</param>
        void Deletar(int id);
    }
}
