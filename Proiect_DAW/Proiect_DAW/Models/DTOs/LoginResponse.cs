using Proiect_DAW.Models;

namespace Proiect_DAW.Models.DTOs
{
    public class LoginResponse
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string token { get; set; }

        public LoginResponse(User user, string tok)
        {
            id = user.Id;
            username = user.Username;
            token = tok;
        }
    }
}
