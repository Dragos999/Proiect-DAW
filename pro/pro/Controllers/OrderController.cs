using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pro.Data;
using pro.Models;
using pro.Services.OrderService;

namespace pro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            return await _orderService.GetOrders();
        }

        [HttpPost]
        public string Add(Guid userId,Guid itemId,string adress="")
        {
            return _orderService.AddOrder(userId,itemId,adress);
        }
        [HttpDelete]
        public string DeleteById(Guid userId,Guid itemId)
        {
            return _orderService.RemoveOrder(userId,itemId);
        }
    }
}
