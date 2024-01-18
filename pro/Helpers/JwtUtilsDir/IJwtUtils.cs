using pro.Models;

namespace pro.Helpers.JwtUtilsDir
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid? GetUserId(string? token);
    }
}
