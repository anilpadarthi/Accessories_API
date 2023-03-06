namespace POS_Accessories.Models.Request
{
    public class OrderProductModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? ProductColourId { get; set; }
        public int? ProductSizeId { get; set; }
    }
}
