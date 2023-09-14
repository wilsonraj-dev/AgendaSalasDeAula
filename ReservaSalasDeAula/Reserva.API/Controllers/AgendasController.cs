using Microsoft.AspNetCore.Mvc;
using Reserva.Application.DTOs;
using Reserva.Application.Interfaces;
using Reserva.Domain.Entidades;
using Reserva.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Reserva.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgendasController : ControllerBase
    {
        private readonly IAgendaService _service;

        public AgendasController(IAgendaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AgendaDTO>>> GetAgendasAsync()
        {
            var result = await _service.GetAgendasAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("agenda-por-data/{dataAgenda:datetime}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AgendaDTO>>> GetAgendasPorDataAsync(DateTime dataAgenda)
        {
            DateTime dataFormatada = new(day: dataAgenda.Month, month: dataAgenda.Day, year: dataAgenda.Year);

            var result = await _service.GetAgendasPorDataAsync(dataFormatada);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet()]
        [Route("agenda-por-professor/{professor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AgendaDTO>>> GetAgendasPorProfessorAsync(string professor)
        {
            var result = await _service.GetAgendasPorProfessorAsync(professor);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AgendaDTO>> CreateAsync([FromBody] AgendaDTO agenda)
        {
            if (agenda == null)
            {
                return BadRequest();
            }
            else if (Convert.ToDateTime(agenda.DataAgenda.ToShortDateString()) < Convert.ToDateTime(DateTime.Today.ToShortDateString()))
            {
                return BadRequest("A data de agendamento da sala não pode ser menor que a data atual.");
            }

            await _service.CreateAsync(agenda);
            return Ok();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AgendaDTO>> UpdateAsync(int id, [FromBody] AgendaDTO agenda)
        {
            if (agenda == null)
            {
                return NotFound();
            }
            else if (agenda.Id != id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(agenda);
            return Ok(agenda);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AgendaDTO>> RemoveAsync(int id)
        {
            var result = await _service.GetAgendaPorIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);
            return NoContent();
        }
    }
}
