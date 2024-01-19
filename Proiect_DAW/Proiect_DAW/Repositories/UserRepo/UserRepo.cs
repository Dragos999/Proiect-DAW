using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Repositories.ReviewRepo;
using Proiect_DAW.Data;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.Generic;

namespace Proiect_DAW.Repositories.UserRepo
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(proContext context) : base(context)
        {

        }
        public async Task<List<string>> UsrOrders(string usrName)
        {
            var usrOrd = _t.Join(_db.Order, u => u.Id, o => o.userId, (u, o) => new
            {
                usrNm = u.Username,
                ordId = o.itemId
            }).Join(_db.Item, a => a.ordId, i => i.Id, (a, i) => new
            { a.usrNm, name = i.Name })
            .Where(a => a.usrNm == usrName).Select(a => a.name).ToList();

            return usrOrd;
        }
        public async Task<User> GetUserByUsername(string name)
        {
            var usr = _t.FirstOrDefault(u => u.Username == name);
            return usr;
        }
    }
}
