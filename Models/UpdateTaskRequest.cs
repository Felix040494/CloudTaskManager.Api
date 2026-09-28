using System.ComponentModel.DataAnnotations;

namespace CloudTaskManager.Api.Models;

public class UpdateTaskRequest
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    [RegularExpression("Pending|InProgress|Completed",
        ErrorMessage = "Status must be Pending, InProgress, or Completed.")]
    public string Status { get; set; } = "Pending";

    public DateTime? DueDate { get; set; }
}
