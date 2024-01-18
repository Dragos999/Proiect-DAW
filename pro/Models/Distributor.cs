using pro.Models.Base;

namespace pro.Models
{
    public class Distributor :BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Item>? items { get; set; }
    }
}
