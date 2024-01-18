using pro.Repositories.OrderRepo;
using pro.Models;
namespace pro.Services.OrderService
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepo.Get();
        }

        public string AddOrder(Guid userId,Guid itemId,string adress="")
        {
            
            string mes1= _orderRepo.Add(userId,itemId,adress);
            string mes2= _orderRepo.Save();
            return (mes1 + "\n" + mes2);
        }
        public async Task<string> RemoveOrder(Guid userId,Guid itemId)
        {
            string mes1=await _orderRepo.DeleteById(userId,itemId);
            string mes2=await _orderRepo.SaveAsync();
            return (mes1 + "\n" + mes2);
        }
    }
}
