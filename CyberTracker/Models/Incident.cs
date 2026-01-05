using System.ComponentModel.DataAnnotations;

namespace CyberTracker.Models
{
    public class Incident
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } // e.g., "SQL Injection in Login"

        [Required]
        public string Description { get; set; }

        [Required]
        public string Severity { get; set; } // Low, Medium, High, Critical

        public string Status { get; set; } = "Open"; // Open, In Progress, Resolved

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Relationship: Who reported this?
        public string? ReporterId { get; set; }
        public ApplicationUser? Reporter { get; set; }
    }
}