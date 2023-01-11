using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int ShopId { get; set; }

    public decimal NetAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal VatAmount { get; set; }

    public decimal DeliveryCharges { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string? ShippingMode { get; set; }

    public byte[]? TrackNumber { get; set; }

    public string? ShippingAddress { get; set; }

    public bool? IsVatEnabled { get; set; }

    public int? VatPercent { get; set; }

    public decimal? DiscountAmount { get; set; }

    public int? DiscountPercent { get; set; }

    public string? CouponCode { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<OrderDetailsMap> OrderDetailsMaps { get; } = new List<OrderDetailsMap>();

    public virtual ICollection<OrderHistoryMap> OrderHistoryMaps { get; } = new List<OrderHistoryMap>();
}
