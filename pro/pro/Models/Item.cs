using pro.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace pro.Models
{
    public class Item:BaseEntity
    {
        

        public int Stock { get; set; }
        
        public int Price { get; set; }
        public string Name { get; set; }
        public ICollection<Order>? orders { get; set; }

        public Guid? distributorId { get; set; }
        public Distributor? distributor { get; set; }

        
    }
}
