using Presentation.Dtos;
using Presentation.Models;

namespace Presentation.Factories;


// Static factory class for converting between DTOs and entities
// Keeps controller logic clean by handling transformation in one place
public class EventFactory
{
    public static EventEntity FromDto(CreateEventDto dto)
    {
        return new EventEntity
        {
            Title = dto.Title,
            Description = dto.Description,
            Start = dto.Start,
            End = dto.End,
            Location = dto.Location,
            Price = dto.Price
        };
    }

    public static EventDto ToDto(EventEntity entity)
    {
        return new EventDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Start = entity.Start,
            End = entity.End,
            Location = entity.Location,
            Price = entity.Price
        };
    }
}