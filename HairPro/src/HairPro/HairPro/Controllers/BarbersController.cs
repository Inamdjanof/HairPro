using HairPro.Application.Features.Barbers.Commands;
using HairPro.Application.Features.Barbers.Queries;
using HairPro.Application.Features.Barbers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BarberController : ControllerBase
{
    private readonly IMediator _mediator;

    public BarberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<BarberResponseModel>>> GetAllBarbers()
    {
        var result = await _mediator.Send(new GetAllBarbersQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BarberResponseModel>> GetBarberById(Guid id)
    {
        var result = await _mediator.Send(new GetBarberByIdQuery { Id = id });
        return Ok(result);
    }



    [HttpPost]
    public async Task<IActionResult> CreateBarber(CreateBarberCommand command)
    {
        var barberId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetBarberById), new { id = barberId }, barberId);
    }

  

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBarber(Guid id, UpdateBarberCommand command)
    {
        if (id != command.Id) return BadRequest("Id does not match.");

        var barberId = await _mediator.Send(command);
        return Ok(barberId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBarber(Guid id)
    {
        var barberId = await _mediator.Send(new DeleteBarberCommand { Id =id});
        return Ok(barberId);
    }
}
