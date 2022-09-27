using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductUsingAPI.Models
{
    public partial class AssignParty
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int ProductId { get; set; }

        public virtual Party Party { get; set; }
        public virtual Product Product { get; set; }
    }
}
