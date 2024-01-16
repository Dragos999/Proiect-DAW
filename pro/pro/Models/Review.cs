using pro.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace pro.Models 
{
    public class Review: BaseEntity
    {
        
        public Guid userId { get; set; }
        public int NrOfStars { get; set; }
        public User? user { get; set; }
        public string Description { get; set; }
    }
}
