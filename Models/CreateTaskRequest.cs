using System.ComponentModel.DataAnnotations;

namespace CloudTaskManager.Api.Models;

public class CreateTaskRequest
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }
}
