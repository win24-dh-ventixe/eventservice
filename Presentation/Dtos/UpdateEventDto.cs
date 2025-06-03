namespace Presentation.Dtos;


// DTO used for updating an existing event
// Contains optional properties to allow partial updates
public class UpdateEventDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public string? Location { get; set; }
    public decimal? Price { get; set; }
}