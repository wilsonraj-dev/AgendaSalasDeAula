using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reserva.Application.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Reserva.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutorizaController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AutorizaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _signInManager = signInManager;
            _configuration = configuration;
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
            var user = new IdentityUser
            {
                UserName = usuario.Nome,
                Email = usuario.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, usuario.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _signInManager.SignInAsync(user, false);
            return Ok(GerarToken(usuario));
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login([FromBody] UsuarioDTO usuario)
        {
            var result = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok();
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
