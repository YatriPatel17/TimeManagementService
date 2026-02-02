using System.ComponentModel.DataAnnotations;

namespace TimeManagementService.Models
{
    public class TimeEntry
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task name is required")]
        [StringLength(100, MinimumLength = 4)]
        public string TaskName { get; set; } = string.Empty;
        
        public string? Description { get; set; }

        [Required(ErrorMessage = "Due date is required!")]
        public DateTime DueDate { get; set; }

        public string? TaskCategory { get; set; }

        [Required(ErrorMessage = "Task status is required")]
        public string TaskStatus { get; set; } = "Pending";

        [Required(ErrorMessage = "Time spent in this task is required")]
        [Range(0, 20000, ErrorMessage = "Time spent must be in 0 to 20000 minutes")]
        public int TimeSpent { get; set; } = 0;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}