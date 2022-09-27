using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductUsingAPI.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int ProductId { get; set; }
        public int CurrentRate { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
