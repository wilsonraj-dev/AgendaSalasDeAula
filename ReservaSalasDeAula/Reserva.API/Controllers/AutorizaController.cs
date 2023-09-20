using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reserva.Application.DTOs;

namespace Reserva.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutorizaController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AutorizaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _signInManager = signInManager;
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

        private object? GerarToken(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }
    }
}
