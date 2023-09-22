using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reserva.Application.DTOs;
using Reserva.Domain.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Reserva.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutorizaController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;

        public AutorizaController(IConfiguration configuration, IAuthenticate authenticate)
        {
            _configuration = configuration;
            _authenticate = authenticate;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "AutorizaController - Acessado em " + DateTime.Now.ToLongDateString();
        }

        [HttpPost]
        [Route("registrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CriarUsario([FromBody] UsuarioDTO usuario)
        {
            var result = await _authenticate.RegisterUser(usuario.Email, usuario.Password);

            if (result)
            {
                return Ok($"User {usuario.Email} was create successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login([FromBody] UsuarioDTO usuario)
        {
            var result = await _authenticate.Authenticate(usuario.Email, usuario.Password);

            if (result)
            {
                return Ok(GerarToken(usuario));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login inválido...");
                return BadRequest(ModelState);
            }
        }

        private UsuarioToken GerarToken(UsuarioDTO usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email),
                new Claim("meuValor", "QualquerCoisa"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiracao = DateTime.UtcNow.AddHours(double.Parse(_configuration["TokenConfiguration:ExpireHours"]));

            //Generate the token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiracao,
                signingCredentials: credencial
                );

            return new UsuarioToken()
            {
                Autenticado = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracao = expiracao,
                Mensagem = "Token Ok"
            };
        }
    }
}
