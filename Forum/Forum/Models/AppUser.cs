using Microsoft.AspNetCore.Identity;

namespace Forum.Models
{
    public class AppUser : IdentityUser
    {
        public string? PathToPhoto { get; set; }
        public bool IsActive { get; set; } // Активный или заблокированый
        public string Sex { get; set; }
        public bool IsTrusted { get; set; } // Довереный или нет
        public DateTime? DeleteTime { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}
