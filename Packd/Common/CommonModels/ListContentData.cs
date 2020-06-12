using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Packd.Common.CommonModels
{
    public class ListContentData
    {
        public int ListId { get; set; }
        public string ListName { get; set; }
        public List<CategoryDisplay> Categories { get; set; }
    }
}
