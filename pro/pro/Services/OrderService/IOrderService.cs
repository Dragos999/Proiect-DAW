using pro.Models;

namespace pro.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();

        string AddOrder(Guid userId,Guid itemID,string adress="");
        string RemoveOrder(Guid userId,Guid itemId);
    }
}
