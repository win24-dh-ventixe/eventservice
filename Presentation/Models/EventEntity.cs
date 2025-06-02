using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class EventEntity
{
    [Key]
    public string Id { get; init; } = Guid.NewGuid().ToString();

    [Required]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    public DateTime Start { get; set; }
    
    public DateTime? End { get; set; }

    [Required]
    public string Location { get; set; } = string.Empty;

    [Required]
    [Precision(10, 2)]
    public decimal Price { get; set; }
}