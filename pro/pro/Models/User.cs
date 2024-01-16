﻿using pro.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace pro.Models
{
    public class User :BaseEntity
    {
        
        public string Username { get; set; }
      
        public string Password { get; set; }
        public ICollection<Order>? orders { get; set; }
        public Review? review { get; set; }
    }
}
