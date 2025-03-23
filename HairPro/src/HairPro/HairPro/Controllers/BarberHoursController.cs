using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HairPro.Application.Features.BarberHours.Commands;
using HairPro.Application.Features.BarberHours.Queries;

namespace HairPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberHoursController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BarberHoursController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Barcha BarberHours ma'lumotlarini olish
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBarberHoursQuery());
            return Ok(result);
        }

        /// <summary>
        /// ID bo‘yicha bitta BarberHours olish
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetBarberHoursByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Yangi BarberHours qo‘shish
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBarberHoursCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        /// <summary>
        /// BarberHours ni yangilash
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBarberHoursCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID mos kelmadi!");

            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// BarberHours ni o‘chirish
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteBarberHoursCommand { Id = id });
            return NoContent();
        }
    }
}
