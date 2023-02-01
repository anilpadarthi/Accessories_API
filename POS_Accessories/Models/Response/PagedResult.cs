namespace POS_Accessories.Models.Response
{
    public class PagedResult
    {
        public IEnumerable<object> Results { get; set; }
        public int TotalRecords { get; set; }
    }
}
