namespace POS_Accessories.Models.Request
{
    public partial class OrderDetailsModel
    {
        public int? OrderId { get; set; }
        public int? UserId { get; set; }
        public int? ShopId { get; set; }
        public decimal? ItemTotal { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? DeliveryCharges { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? TotalWithVATAmount { get; set; }
        public decimal? TotalWithOutVATAmount { get; set; }
        public string? CouponCode { get; set; }
        public string? OrderStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string? ShippingMode { get; set; }
        public string? TrackNumber { get; set; }
        public string? ShippingAddress { get; set; }
        public decimal? VatPercentage { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public List<OrderProductModel> Items { get; set; }

    }
}
