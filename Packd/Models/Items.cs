using System;
using System.Collections.Generic;

namespace Packd.Models
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int IsDefault { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
