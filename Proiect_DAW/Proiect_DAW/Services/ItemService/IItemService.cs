using Proiect_DAW.Models;

namespace Proiect_DAW.Services.ItemService
{
    public interface IItemService
    {
        Task<List<Item>> GetItems();

        string AddItem(Item item);

        Task<string> RemoveItem(Guid id);
    }
}
