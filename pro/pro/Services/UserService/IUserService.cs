using pro.Models;

namespace pro.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        string AddUser(User user);

        string RemoveUser(Guid id);

        List<string> GetUserOrders(Guid id);
    }
}
