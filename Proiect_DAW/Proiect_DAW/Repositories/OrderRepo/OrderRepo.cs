using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Data;
using Proiect_DAW.Models;

namespace Proiect_DAW.Repositories.OrderRepo
{
    public class OrderRepo : IOrderRepo
    {
        protected readonly proContext _db;
        protected readonly DbSet<Order> _t;

        public OrderRepo(proContext context)
        {
            _db = context;
            _t = context.Set<Order>();
        }

        //Get
        public async Task<List<Order>> Get()
        {
            return await _t.ToListAsync();
        }

        //Create
        public string Add(Guid usrId, Guid itmId, string adress = "")
        {

            var usr = _db.User.Find(usrId);
            var itm = _db.Item.Find(itmId);
            Console.WriteLine("| itmId: ", itmId);
            Console.WriteLine("UsrId1: ", usrId);
            if (usr != null && itm != null)
            {
                var newOrd = new Order
                {
                    user = usr,
                    item = itm,
                    userId = usrId,
                    itemId = itmId,
                    Adress = adress
                };

                if (itm.Stock == 0)
                {
                    return "Out of stock!";
                }
                else
                {
                    itm.Stock--;
                    _t.Add(newOrd);
                    return "Order added!";
                }
            }
            else
            {
                return "User or item not found!";
            }

        }

        //Find

        public async Task<Order> FindById(Guid id)
        {
            return await _t.FindAsync(id);
        }
        //Delete
        public async Task<string> DeleteById(Guid userId, Guid itemId)
        {
            var ord = _t.FirstOrDefault(o => o.itemId == itemId && o.userId == userId);
            if (ord != null)
            {

                _t.Remove(ord);
                return "Order Removed!";
            }
            else
            {
                return "Order not found!";
            }
        }
        //Save

        public string Save()
        {
            try
            {
                _db.SaveChanges();

            }
            catch
            {
                return "Saving Failed!";
            }
            return "Saved successfully!";
        }

        //Save async

        public async Task<string> SaveAsync()
        {
            try
            {
                _db.SaveChangesAsync();

            }
            catch
            {
                return "Saving Failed!";
            }
            return "Saved successfully!";
        }
    }
}
