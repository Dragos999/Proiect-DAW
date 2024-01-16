using pro.Repositories.Generic;
using pro.Models;

namespace pro.Repositories.UserRepo
{
    public interface IUserRepo : IGenericRepo<User>
    {
        List<string> UsrOrders(Guid id);
    }
}
