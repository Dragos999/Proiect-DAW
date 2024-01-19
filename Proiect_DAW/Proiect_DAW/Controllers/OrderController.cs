using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Data;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Helpers.Attributes;
using Proiect_DAW.Models;
using Proiect_DAW.Roles;
using Proiect_DAW.Services.OrderService;

namespace Proiect_DAW.Controllers
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
        public string Add(Guid userId, Guid itemId, string address = "")
        {
            Console.WriteLine(itemId);
            Console.WriteLine(userId);
            Console.WriteLine(address);
            return _orderService.AddOrder(userId, itemId, address);
        }


        [Authorize(Role.Admin)]
        [HttpDelete]
        public async Task<string> DeleteById(Guid userId, Guid itemId)
        {
            return await _orderService.RemoveOrder(userId, itemId);
        }
    }
}
