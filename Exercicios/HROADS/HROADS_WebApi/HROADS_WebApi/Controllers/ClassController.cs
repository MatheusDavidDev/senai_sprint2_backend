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
    public class ClassController : ControllerBase
    {
        private IClassRepository _classeRepository { get; set; }

        public ClassController()
        {
            _classeRepository = new ClassRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_classeRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Class classeBuscada = _classeRepository.BuscarPorId(id);

            if (classeBuscada == null)
            {
                return NotFound("Nenhuma classe foi encontrada");
            }

            try
            {
                return Ok(classeBuscada);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Class novaClasse)
        {
            try
            {
                _classeRepository.Cadastrar(novaClasse);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Class classeAtualizada)
        {
            Class classeBuscada = _classeRepository.BuscarPorId(id);

            if (classeBuscada == null)
            {
                return NotFound(new 
                { mensagem = "Classe não encontrada!", 
                  erro = true 
                });
            }

            try
            {
                _classeRepository.Atualizar(id, classeAtualizada);

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
            Class classeBuscada = _classeRepository.BuscarPorId(id);

            if (classeBuscada == null)
            {
                return NotFound(new
                {
                    mensagem = "Classe não encontrada!",
                    erro = true
                });
            }

            try
            {
                _classeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
           
        }

        [HttpGet("classes")]
        public IActionResult GetP()
        {
            try
            {
                return Ok(_classeRepository.ListarPersonagens());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }

    }
}
