using Proiect_DAW.Models;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Roles;

namespace Proiect_DAW.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        string AddUser(User user);
        Task<LoginResponse> Login(LoginDTO user);
        string Register(RegisterDTO userRegisterDto, Role userRole);
        Task<string> RemoveUser(Guid id);
        User GetUserById(Guid id);
        Task<List<string>> GetUserOrders(string name);
        Task<string> UpdateUserReview(Guid id, int nrOfStars, string description);
    }
}
