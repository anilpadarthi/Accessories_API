namespace POS_Accessories.Models.Response
{
    public class WareHouseResult
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int? BuyTotal { get; set; }
        public int? SaleTotal { get; set; }
    }
}
