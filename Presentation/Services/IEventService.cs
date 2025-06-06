using Presentation.Dtos;
using Presentation.Models;

namespace Presentation.Services
{
    public interface IEventService
    {
        Task<EventEntity> CreateAsync(EventEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<EventDto>> GetAllAsync();
        Task<EventDto?> GetByIdAsync(Guid id);
        Task<EventDto?> UpdateAndReturnAsync(Guid id, UpdateEventDto dto);
    }
}