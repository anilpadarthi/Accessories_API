namespace POS_Accessories.Models.Response
{
    public class StockPurchaseHistoryResult
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductCode { get; set; }
        public int? SupplierId { get; set; }
        public string? InvoiceNumber { get; set; }
        public int? Qty { get; set; }
        public decimal? BuyPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
