using System;
using System.Collections.Generic;

namespace Packd.Models
{
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Items>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int IsDefault { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
