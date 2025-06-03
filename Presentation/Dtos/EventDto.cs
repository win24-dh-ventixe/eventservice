namespace Presentation.Dtos;


// DTO used for sending event data back to the client
// Represents a simplified version of the full EventEntity
public class EventDto
{
    public string Id { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime Start { get; init; }
    public DateTime? End { get; init; }
    public string Location { get; init; } = string.Empty;
    public decimal Price { get; init; }
}
