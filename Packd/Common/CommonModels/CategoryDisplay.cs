using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Packd.Common.CommonModels
{
    public class CategoryDisplay
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ItemDisplay> Items { get; set; }
    }
}
