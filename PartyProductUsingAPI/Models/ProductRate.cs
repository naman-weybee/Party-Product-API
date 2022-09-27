using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductUsingAPI.Models
{
    public partial class ProductRate
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Rate { get; set; }
        public DateTime DateOfRate { get; set; }

        public virtual Product Product { get; set; }
    }
}
