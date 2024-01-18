using pro.Repositories.Generic;
using pro.Models;

namespace pro.Repositories.UserRepo
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<List<string>> UsrOrders(string name);
        Task<User> GetUserByUsername(string name);
    }
}
