using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Data;
using Proiect_DAW.Helpers.Attributes;
using Proiect_DAW.Services.ItemService;
using Proiect_DAW.Roles;
using Proiect_DAW.Models;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
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
            return _itemService.AddItem(item);
        }

        [Authorize(Role.Admin)]
        [HttpDelete]
        public async Task<string> DeleteById(Guid id)
        {
            return await _itemService.RemoveItem(id);
        }



    }
}
