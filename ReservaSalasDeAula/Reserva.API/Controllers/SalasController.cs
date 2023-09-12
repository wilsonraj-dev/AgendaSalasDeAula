using Microsoft.AspNetCore.Mvc;
using Reserva.Application.DTOs;
using Reserva.Application.Interfaces;

namespace Reserva.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly ISalaService _service;

        public SalasController(ISalaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SalaDTO>>> GetSalasAsync()
        {
            var result = await _service.GetSalasAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SalaDTO>> CreateAsync([FromBody] SalaDTO sala)
        {
            if (sala == null)
            {
                return BadRequest();
            }

            await _service.CreateAsync(sala);
            return Ok(sala);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalaDTO>> UpdateAsync(int id, [FromBody] SalaDTO sala)
        {
            if (sala == null)
            {
                return NotFound();
            }
            else if (sala.Id != id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(sala);
            return Ok(sala);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalaDTO>> RemoveAsync(int id)
        {
            var result = await _service.GetSalaByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);
            return NoContent();
        }
    }
}
