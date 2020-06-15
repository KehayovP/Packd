namespace Packd.Common.CommonModels
{
    public class ListContentDataRaw
    {
        public int ListContentId { get; set; }
        public int ListId { get; set; }
        public string ListName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public bool IsPacked { get; set; }
    }
}
