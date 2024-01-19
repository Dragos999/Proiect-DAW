using Proiect_DAW.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proiect_DAW.Models
{
    public class Review : BaseEntity
    {

        public Guid userId { get; set; }
        public int NrOfStars { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public User? user { get; set; }

    }
}
