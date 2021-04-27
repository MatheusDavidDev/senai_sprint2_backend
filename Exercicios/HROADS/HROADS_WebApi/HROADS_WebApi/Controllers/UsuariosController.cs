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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_usuarioRepository.Listar());
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
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound("Nenhum usuario foi encontrado");
            }

            try
            {

                return Ok(usuarioBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound(new
                {
                    mensagem = "Usuario não encontrado!",
                    erro = true
                });
            }

            try
            {

                _usuarioRepository.Atualizar(id, usuarioAtualizado);

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
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound(new
                {
                    mensagem = "Usuario não encontrado!",
                    erro = true
                });
            }

            try
            {

                _usuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

    }
}
