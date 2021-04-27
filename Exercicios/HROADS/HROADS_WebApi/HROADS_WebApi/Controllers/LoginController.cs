using HROADS_WebApi.Domains;
using HROADS_WebApi.Interfaces;
using HROADS_WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HROADS_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            Usuario userBuscado = _usuarioRepository.Login(login.Email, login.Senha);

            if (userBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }

            var clams = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, userBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, userBuscado.IdTipoUsuario.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-matheus-david-api"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: "Hroads.webApi",
                    audience: "Hroads.webApi",
                    claims: clams,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
