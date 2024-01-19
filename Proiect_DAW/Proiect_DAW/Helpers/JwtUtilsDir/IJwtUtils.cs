using Proiect_DAW.Models;

namespace Proiect_DAW.Helpers.JwtUtilsDir
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid? GetUserId(string? token);
    }
}
