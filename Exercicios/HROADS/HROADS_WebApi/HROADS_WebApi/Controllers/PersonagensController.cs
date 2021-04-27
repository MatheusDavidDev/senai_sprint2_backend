using HROADS_WebApi.Domains;
using HROADS_WebApi.Interfaces;
using HROADS_WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [Authorize]
        [HttpGet]
        public  IActionResult Get()
        {
            try
            {
                return Ok(_personagemRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Personagen personagemBuscado = _personagemRepository.BuscarPorId(id);

            if (personagemBuscado == null)
            {
                return NotFound("Nenhum personagem foi encontrado");
            }

            try
            {
                return Ok(personagemBuscado);
             
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagen novoPersonagem)
        {
            try
            {
                _personagemRepository.Cadastrar(novoPersonagem);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagen personagemAtualizado)
        {
            Personagen personagemBuscado = _personagemRepository.BuscarPorId(id);

            if (personagemBuscado == null)
            {
                return NotFound(new
                {
                    mensagem = "Personagem não encontrado!",
                    erro = true
                });
            }

            try
            {
                _personagemRepository.Atualizar(id, personagemAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Personagen personagemBuscado = _personagemRepository.BuscarPorId(id);

            if (personagemBuscado == null)
            {
                return NotFound(new
                {
                    mensagem = "Personagem não encontrado!",
                    erro = true
                });
            }

            try
            { 
                _personagemRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [Authorize]
        [HttpGet("users")]
        public IActionResult GetU()
        {
            try
            {
                return Ok(_personagemRepository.ListarUsuarios());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
