using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;
using Presentation.Factories;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventService eventService) : ControllerBase
{
    private readonly IEventService _eventService = eventService;

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _eventService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _eventService.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEventDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);       
            
        var entity = EventFactory.FromDto(dto);
        var createdEntity = await _eventService.CreateAsync(entity);

        return CreatedAtAction(nameof(Get), new { id = createdEntity.Id }, createdEntity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var success = await _eventService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
