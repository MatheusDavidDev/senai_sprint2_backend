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
    public class TiposUsuariosController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_tiposUsuarioRepository.Listar());
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
            TiposUsuario tipoBuscado = _tiposUsuarioRepository.BuscarPorId(id);

            if (tipoBuscado == null)
            {
                return NotFound("Nenhum Tipo de usuario foi encontrado");
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
        public IActionResult Post(TiposUsuario novoTipo)
        {
            try
            {

                _tiposUsuarioRepository.Cadastrar(novoTipo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tiposAtualizado)
        {
            TiposUsuario tipoBuscado = _tiposUsuarioRepository.BuscarPorId(id);

            if (tipoBuscado == null)
            {
                return NotFound(new
                {
                    mensagem = "Tipo de usuario não encontrado!",
                    erro = true
                });
            }

            try
            {

                _tiposUsuarioRepository.Atualizar(id, tiposAtualizado);

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
            TiposUsuario tipoBuscado = _tiposUsuarioRepository.BuscarPorId(id);

            if (tipoBuscado == null)
            {
                return NotFound(new
                {
                    mensagem = "Tipo de usuario não encontrado!",
                    erro = true
                });
            }

            try
            {
                
                _tiposUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [Authorize]
        [HttpGet("tipousers")]
        public IActionResult GetU()
        {
            try
            {

                return Ok(_tiposUsuarioRepository.ListarUsuarios());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
