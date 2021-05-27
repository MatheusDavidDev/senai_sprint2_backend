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
    public class TipoDeHabilidadesController : ControllerBase
    {
        private ITiposDeHabilidadesRepository _tipoDeHabilidadeRepository { get; set; }

        public TipoDeHabilidadesController()
        {
            _tipoDeHabilidadeRepository = new TiposDeHabilidadesRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoDeHabilidadeRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TiposDeHabilidade tipoBuscado = _tipoDeHabilidadeRepository.BuscarPorId(id);

            if (tipoBuscado == null)
            {
                return NotFound("Nenhum Tipo de habilidade foi encontrado");
            }

            try
            {
                return Ok(tipoBuscado);               
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TiposDeHabilidade novoTipo)
        {
            try
            {
                _tipoDeHabilidadeRepository.Cadastrar(novoTipo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposDeHabilidade tipoAtualizado)
        {
            TiposDeHabilidade tipoBuscado = _tipoDeHabilidadeRepository.BuscarPorId(id);

            if (tipoBuscado == null)
            {
                return NotFound(new
                {
                    mensagem = "Tipo de habilidade não encontrada!",
                    erro = true
                });
            }

            try
            {
                _tipoDeHabilidadeRepository.Atualizar(id, tipoAtualizado);

                return StatusCode(204);            
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TiposDeHabilidade tipoBuscado = _tipoDeHabilidadeRepository.BuscarPorId(id);

            if (tipoBuscado == null)
            {
                return NotFound(new
                {
                    mensagem = "Tipo de habilidade não encontrada!",
                    erro = true
                });
            }

            try
            {                
                _tipoDeHabilidadeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpGet("skills")]
        public IActionResult GetS()
        {
            try
            {

                return Ok(_tipoDeHabilidadeRepository.ListarHabilidades());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


    }
}
