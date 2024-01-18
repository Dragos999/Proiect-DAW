using System.ComponentModel.DataAnnotations.Schema;
using pro.Models.Base;
namespace pro.Models
{
    public class Order 
    {
        

        public Guid userId { get; set; }
        public Guid itemId { get; set; }
        public string Adress { get; set; }
        public User? user { get; set; }
        public Item? item { get; set; }

    }
}
