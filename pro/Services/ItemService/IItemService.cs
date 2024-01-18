using pro.Models;

namespace pro.Services.ItemService
{
    public interface IItemService
    {
        Task<List<Item>> GetItems();

        string AddItem(Item item);

        Task<string> RemoveItem(Guid id);
    }
}
