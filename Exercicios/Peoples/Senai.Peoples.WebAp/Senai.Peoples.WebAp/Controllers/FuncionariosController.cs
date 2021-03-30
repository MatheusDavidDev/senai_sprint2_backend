using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebAp.Domains;
using Senai.Peoples.WebAp.Interfaces;
using Senai.Peoples.WebAp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAp.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        ///  Lista todos os funcionaris
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                List<FuncionarioDomain> listaFuncionario = _funcionarioRepository.ListarTodos();

                return Ok(listaFuncionario);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Procura um funcionario pelo seu id
        /// </summary>
        /// <param name="id">id do funcionario procurado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionarioDomain funcionaroBuscado = _funcionarioRepository.BuscarPorId(id);

            try
            {
                if (funcionaroBuscado == null)
                {
                    return NotFound("Nenhum Funcionario foi encontrado");
                }

                return Ok(funcionaroBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra novo funcionario
        /// </summary>
        /// <param name="novoFuncionaro">informacoes do novo funcionario</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionaro)
        {
            try
            {
                _funcionarioRepository.Cadastrar(novoFuncionaro);

                return StatusCode(201);

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um funcionario
        /// </summary>
        /// <param name="id">id do funcionario para ser deletado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _funcionarioRepository.deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        ///  Atualiza um funcionario
        /// </summary>
        /// <param name="id">id do funcionario para atualizar</param>
        /// <param name="funcionarioAtualizado">novas informacoes do usuario</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, FuncionarioDomain funcionarioAtualizado)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            try
            {
                _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
