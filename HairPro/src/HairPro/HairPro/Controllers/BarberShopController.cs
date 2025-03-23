using HairPro.Application.Features.Barbers.Commands;
using HairPro.Application.Features.Barbers.Queries;
using HairPro.Application.Features.BarberShops.Commands;
using HairPro.Application.Features.BarberShops.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HairPro.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BarberShopController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BarberShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBarberShopsQuery());
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetBarberShopByIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBarberShopCommand command)
        {
            var newId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBarberShopCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID mos kelmadi");

            var updatedId = await _mediator.Send(command);
            return Ok(updatedId);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteBarberShopCommand { Id = id });
            return result ? NoContent() : NotFound();
        }
    }




}

