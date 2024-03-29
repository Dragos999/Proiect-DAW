﻿using Proiect_DAW.Models;
using Proiect_DAW.Repositories.ItemRepo;

namespace Proiect_DAW.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly IItemRepo _itemRepo;

        public ItemService(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public async Task<List<Item>> GetItems()
        {
            return await _itemRepo.Get();
        }

        public string AddItem(Item item)
        {

            string mes1 = _itemRepo.Add(item);
            string mes2 = _itemRepo.Save();
            return mes1 + "\n" + mes2;
        }

        public async Task<string> RemoveItem(Guid id)
        {

            string mes1 = await _itemRepo.DeleteById(id);
            string mes2 = await _itemRepo.SaveAsync();
            return mes1 + "\n" + mes2;
        }



    }
}
