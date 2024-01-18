using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pro.Data;
using pro.Models.DTOs;
using pro.Roles;
using pro.Helpers.Attributes;
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            return await _orderService.GetOrders();
        }

        [Authorize(Role.User)]
        [HttpPost]
        public string Add(Guid userId,Guid itemId,string address="")
        {
            Console.WriteLine( itemId);
            Console.WriteLine( userId);
            Console.WriteLine( address);
            return  _orderService.AddOrder(userId,itemId,address);
        }


        [Authorize(Role.Admin)]
        [HttpDelete]
        public async Task<string> DeleteById(Guid userId,Guid itemId)
        {
            return await _orderService.RemoveOrder(userId,itemId);
        }
    }
}
