using pro.Models;

namespace pro.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        string AddUser(User user);

        string RemoveUser(Guid id);

        List<string> GetUserOrders(string name);
        string UpdateUserReview(string name,int nrOfStars,string description);
    }
}
