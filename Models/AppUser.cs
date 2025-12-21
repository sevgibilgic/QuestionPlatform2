using Microsoft.AspNetCore.Identity;

namespace QuestionPlatform2.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
