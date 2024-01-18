using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using pro.Models;
using pro.Data;
using pro.Services.ItemService;
using pro.Helpers.Attributes;
using pro.Roles;

namespace pro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController (IItemService itemService)
        {
            _itemService = itemService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Item>> GetItems()
        {
            return await _itemService.GetItems();
        }

        [Authorize(Role.Admin)]
        [HttpPost]
        public string Add(Item item)
        {
            return  _itemService.AddItem(item);
        }

        [Authorize(Role.Admin)]
        [HttpDelete]
        public async Task<string> DeleteById(Guid id)
        {
            return await _itemService.RemoveItem(id);
        }



    }
}
