using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Packd.Common.CommonModels
{
    public class ItemDisplay
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public bool IsPacked { get; set; }
        public int ListContentId { get; set; }
    }
}
