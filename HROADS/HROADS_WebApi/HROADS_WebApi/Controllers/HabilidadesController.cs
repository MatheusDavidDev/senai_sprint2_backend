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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_habilidadeRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Habilidade habilidadeBuscada = _habilidadeRepository.BuscarPorId(id);

            if (habilidadeBuscada == null)
            {
                return NotFound("Nenhuma habilidade foi encontrada");
            }

            try
            {
                return Ok(habilidadeBuscada);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

            
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            try
            {
                _habilidadeRepository.Cadastrar(novaHabilidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = _habilidadeRepository.BuscarPorId(id);

            if (habilidadeBuscada == null)
            {
                return NotFound(new
                {
                    mensagem = "Habilidade não encontrada!",
                    erro = true
                });
            }

            try
            {
                _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

                return StatusCode(201);
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
            Habilidade habilidadeBuscada = _habilidadeRepository.BuscarPorId(id);

            if (habilidadeBuscada == null)
            {
                return NotFound(new
                {
                    mensagem = "Habilidade não encontrada!",
                    erro = true
                });
            }

            try
            {
                _habilidadeRepository.Deletar(id);

                return StatusCode(204);

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }


            
        }
    }
}
