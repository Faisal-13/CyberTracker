using System.ComponentModel.DataAnnotations;

namespace CyberTracker.Models
{
    public class SecurityTip
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } // e.g. "Beware of Phishing Emails"

        [Required]
        public string Content { get; set; } // e.g. "Never click links from..."

        [Required]
        public string KnowledgeLevel { get; set; } // Basic, Intermediate, Advanced

        public DateTime PostedDate { get; set; } = DateTime.Now;
    }
}