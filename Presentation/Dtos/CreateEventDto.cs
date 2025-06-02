using System.ComponentModel.DataAnnotations;

namespace Presentation.Dtos;

public class CreateEventDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    public DateTime Start { get; set; }

    public DateTime? End { get; set; }

    [Required]
    public string Location { get; set; } = string.Empty;

    [Required]
    [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10,000.")]
    public decimal Price { get; set; } = 0.0m;
}