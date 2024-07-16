using Microsoft.AspNetCore.Identity;

namespace SpassoCasa_Backend.Model.JWT
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}
