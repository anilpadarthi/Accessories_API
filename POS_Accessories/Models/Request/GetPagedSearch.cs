namespace POS_Accessories.Models.Request
{
    public class GetPagedSearch
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int? id { get; set; }
        public string? searchText { get; set; }
        public string? mode { get; set; }
        public int? loggedInUserId { get; set; }
    }
}
