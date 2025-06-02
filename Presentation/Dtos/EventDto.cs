namespace Presentation.Dtos;

public class EventDto
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
    public string Location { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
