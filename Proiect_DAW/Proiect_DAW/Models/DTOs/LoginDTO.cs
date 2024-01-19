using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
