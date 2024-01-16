using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using pro.Models;
using pro.Data;
using pro.Services.ItemService;

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

        [HttpGet]
        public async Task<List<Item>> GetItems()
        {
            return await _itemService.GetItems();
        }


        [HttpPost]
        public string Add(Item item)
        {
            return _itemService.AddItem(item);
        }

        [HttpDelete]
        public string DeleteById(Guid id)
        {
            return _itemService.RemoveItem(id);
        }



    }
}
