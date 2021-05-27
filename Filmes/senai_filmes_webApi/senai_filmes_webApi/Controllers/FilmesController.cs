using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Controllers
{
    [Produces("application/json")]

    // http://localhost:5000/api/Filmes
    [Route("api/[controller]")]

    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmesRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmesRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

            return Ok(listaFilmes);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }
    }
}
