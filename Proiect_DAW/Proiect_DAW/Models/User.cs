using Proiect_DAW.Models.Base;
using Proiect_DAW.Roles;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_DAW.Models
{
    public class User : BaseEntity
    {

        public string Username { get; set; }

        public string Password { get; set; }
        public ICollection<Order>? orders { get; set; }
        public Review? review { get; set; }

        public Role Role { get; set; }
    }
}
