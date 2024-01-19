using System.ComponentModel.DataAnnotations.Schema;
using Proiect_DAW.Models.Base;

namespace Proiect_DAW.Models
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
