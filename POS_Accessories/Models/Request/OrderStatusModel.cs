namespace POS_Accessories.Models.Request
{
    public partial class OrderStatusModel
    {
        public int OrderId { get; set; }
        public string? OrderStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string? ShippingMode { get; set; }
        public string? TrackNumber { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
