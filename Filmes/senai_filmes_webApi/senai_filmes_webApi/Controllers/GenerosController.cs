using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsavel pelos endpoints (URLs) referente aos generos
/// </summary>

namespace senai_filmes_webApi.Controllers
{
    // Define que o tipo de responta da API sera no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisicao sera no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Generos
    [Route("api/[controller]")]

    // Define que e um controlador de API 
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que ira receber todos os metodos definidos na interface IGenerosRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja a referencia aos metodos no repositorio
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os generos
        /// </summary>
        /// <returns> Uma Lista de generos e um status code</returns>
        /// dominio/api/generos
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com uma lista de genero no formato JSON
            return Ok(listaGeneros);
        }

        /// <summary>
        /// Busca um genero atraves do seu id
        /// </summary>
        /// <param name="id"> id do genero que sera bucado</param>
        /// <returns> Um genero buscado ou NotFound caso nenhum genero seja encontrado </returns>
        /// http://localhost:5000/api/generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto genero buscadoque ira recebero genero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscasPorId(id);

            // Verifica se nenhum genero foi encontrado
            if (generoBuscado == null)
            {
                // Caso nao senha encontrado, retorna um status code 404 - Not Found com mensagem personalizada
                return NotFound("Nenhum genero foi encontrado!");
            }

            // Caso seja encontrado, retorna o genero buscado com um status code 200 = Ok
            return Ok(generoBuscado);
        }

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto novo genero recebido na requisicao</param>
        /// <returns>Um status code 201 - created </returns>
        /// http://localhost:5000/api/generos
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // Faz a chamada para o metodo .Cadastrar()
            _generoRepository.Cadastrar(novoGenero);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza o genero existente passando seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="id">id do genero que sera atualizado</param>
        /// <param name="generoAtualizado"> objeto generoAtualizado com as novas informacoes</param>
        /// <returns> Um Status Code </returns>
        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que ira receber o genero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscasPorId(id);

            // Caso nao seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (generoBuscado == null)
            {
                return NotFound(new
                {
                    mensagem = "Genero nao encontrado!",
                    erro = true
                });
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o metodo AtualizarIdUrl passando os parametros
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                // Retorna um StatusCode 204 - No content
                return NoContent();
            }
            // Caso ocorra algum erro 
            catch (Exception erro)
            {
                // Retorna um status code 400 - BadRequest e o codigo de erro
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza um genero existente passando su id pelo corpo da requisicao
        /// </summary>
        /// <param name="generoAtualizado"> Objeto genero atualizado com as novas informacoes</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que ira receber o genero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscasPorId(generoAtualizado.idGenero);

            // Verifica se algum genero foi encontrado 
            if (generoBuscado != null)
            {
                // Se sim, tenta atualizar o registro
                try
                {
                    // Faz a chamada para o metodos .AtualizaIdCorpo()
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    //retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna um BadRequest e o codigo de erro
                    return BadRequest(erro);
                }
            }

            // Caso nao seja encontrado, retorna NotFound com uma mensagem personalizada
            return NotFound(new
            {
                mensagem = "Genero nao encontrado!",

            });

        }

        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="id">id do genero que sera deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        /// [HttpDelete("{id}")] - Deleta pelo id que esta no meu url
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o metodo deletar
            _generoRepository.Deletar(id);

            // Retorna o StatusCode 204 - No Content
            return StatusCode(204);
        }


    }
}
