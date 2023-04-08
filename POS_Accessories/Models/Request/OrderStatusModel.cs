namespace POS_Accessories.Models.Request
{
    public partial class OrderStatusModel
    {
        public int OrderId { get; set; }
        public int? OrderStatusId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? ShippingModeId { get; set; }
        public string? TrackNumber { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
