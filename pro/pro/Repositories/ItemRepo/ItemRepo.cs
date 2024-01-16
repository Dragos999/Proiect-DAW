using pro.Repositories.Generic;
using pro.Models;
using pro.Data;

namespace pro.Repositories.ItemRepo
{
    public class ItemRepo :GenericRepo<Item>,IItemRepo
    {
        public ItemRepo(proContext context) : base(context)
        {

        }
    }
}
