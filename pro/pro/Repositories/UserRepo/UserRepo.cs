using pro.Data;
using pro.Models;
using pro.Repositories.Generic;

namespace pro.Repositories.UserRepo
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(proContext context) : base(context)
        {
           
        }
        public List<string>UsrOrders(Guid id)
        {
            var usrOrd = _t.Join(_db.Order, u => u.Id, o => o.userId, (u, o) => new
            {
                usrId = u.Id,
                ordId = o.itemId
            }).Join(_db.Item, a => a.ordId, i => i.Id, (a, i) => new
            { a.usrId, name = i.Name })
            .Where(a => a.usrId == id).Select(a => a.name).ToList();

            return usrOrd;
        }
        
    }
}
