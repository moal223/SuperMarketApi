using Microsoft.AspNetCore.Identity;

namespace supermarket.domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}