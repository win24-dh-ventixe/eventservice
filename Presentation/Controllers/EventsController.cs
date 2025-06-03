using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;
using Presentation.Factories;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventService eventService) : ControllerBase
{
    private readonly IEventService _eventService = eventService;


    // GET /api/events
    // Returns all events
    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _eventService.GetAllAsync());


    // GET /api/events/{id}
    // Returns a specific event by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _eventService.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }


    // POST /api/events
    // Creates a new event based on input DTO
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEventDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);       
            
        var entity = EventFactory.FromDto(dto);
        var createdEntity = await _eventService.CreateAsync(entity);

        return CreatedAtAction(nameof(Get), new { id = createdEntity.Id }, createdEntity);
    }


    // DELETE /api/events/{id}
    // Deletes an event by ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _eventService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }

    // PUT /api/events/{id}
    // Updates an existing event by ID using the provided DTO
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateEventDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var updated = await _eventService.UpdateAndReturnAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }
}
