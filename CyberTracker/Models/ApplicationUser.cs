using Microsoft.AspNetCore.Identity;

namespace CyberTracker.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add extra fields if needed, e.g., Department
        public string? Department { get; set; }
    }
}