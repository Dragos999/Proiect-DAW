using System.ComponentModel.DataAnnotations;

namespace pro.Models.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }

    }
}
