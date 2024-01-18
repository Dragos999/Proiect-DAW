using pro.Models;
using pro.Roles;
using pro.Models.DTOs;
namespace pro.Services.UserService
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
        Task<string> UpdateUserReview(Guid id, int nrOfStars,string description);
    }
}
