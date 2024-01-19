using Proiect_DAW.Repositories.Generic;
using Proiect_DAW.Models;
using Proiect_DAW.Data;

namespace Proiect_DAW.Repositories.ItemRepo
{
    public class ItemRepo : GenericRepo<Item>, IItemRepo
    {
        public ItemRepo(proContext context) : base(context)
        {

        }
    }
}
