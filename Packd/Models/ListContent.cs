using System;
using System.Collections.Generic;

namespace Packd.Models
{
    public partial class ListContent
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public int CategoryId { get; set; }
        public int ItemId { get; set; }
        public int IsPacked { get; set; }
    }
}
