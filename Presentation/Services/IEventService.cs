using Presentation.Models;

namespace Presentation.Services
{
    public interface IEventService
    {
        Task<EventEntity> CreateAsync(EventEntity entity);
        Task<bool> DeleteAsync(string id);
        Task<IEnumerable<EventEntity>> GetAllAsync();
        Task<EventEntity?> GetByIdAsync(string id);
    }
}