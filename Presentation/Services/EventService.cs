using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Models;

namespace Presentation.Services;

public class EventService(EventDbContext context) : IEventService
{
    public readonly EventDbContext _context = context;

    // Returns all events from the database
    public async Task<IEnumerable<EventEntity>> GetAllAsync() =>
        await _context.Events.ToListAsync();


    // Finds a single event by ID
    public async Task<EventEntity?> GetByIdAsync(string id) =>
        await _context.Events.FindAsync(id);


    // Adds a new event to the database
    public async Task<EventEntity> CreateAsync(EventEntity entity)
    {
        _context.Events.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }


    // Deletes an event by ID
    public async Task<bool> DeleteAsync(string id)
    {
        var entity = await _context.Events.FindAsync(id);
        if (entity == null) return false;
        _context.Events.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
};