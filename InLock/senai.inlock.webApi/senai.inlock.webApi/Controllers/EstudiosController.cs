using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista Estudio
        /// </summary>
        /// <returns>Uma lista de estudios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> listaEstudio = _estudioRepository.ListarTodos();

            return Ok(listaEstudio);
        }

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto com os dados do novo estudio</param>
        /// <returns>Um status code 201</returns>
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um estudio pelo id
        /// </summary>
        /// <param name="estudioAtuali">Objeto do estudio atualizado</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(EstudioDomain estudioAtuali)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(estudioAtuali.idEstudio);

            if (estudioBuscado != null)
            {
                try
                {
                    _estudioRepository.AtualizarIdCorpo(estudioAtuali);

                    return NoContent();
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                 
                }
            }

            return NotFound(new
            {
                mensagem = "Estudio nao encontrado!",
            });
        }

        /// <summary>
        /// Deleta um estudio que existe
        /// </summary>
        /// <param name="id">id do estudio deletado</param>
        /// <returns>status code </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estudioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
