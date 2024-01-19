using Proiect_DAW.Models;
using Proiect_DAW.Repositories.Generic;

namespace Proiect_DAW.Repositories.UserRepo
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<List<string>> UsrOrders(string name);
        Task<User> GetUserByUsername(string name);
    }
}
