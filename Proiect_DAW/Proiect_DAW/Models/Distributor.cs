﻿using Proiect_DAW.Models.Base;

namespace Proiect_DAW.Models
{
    public class Distributor : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Item>? items { get; set; }
    }
}
