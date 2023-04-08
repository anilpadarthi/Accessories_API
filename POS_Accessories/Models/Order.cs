using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? ShopId { get; set; }
    public decimal? ItemTotal { get; set; }
    public decimal? NetAmount { get; set; }
    public decimal? VatAmount { get; set; }
    public decimal? DeliveryCharges { get; set; }
    public decimal? DiscountAmount { get; set; }
    public decimal? TotalWithVATAmount { get; set; }
    public decimal? TotalWithOutVATAmount { get; set; }

    public string? TrackNumber { get; set; }

    public string? ShippingAddress { get; set; }

    public bool? IsVatEnabled { get; set; }

    public decimal? VatPercentage { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public string? CouponCode { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }
    public int? OrderStatusId { get; set; }
    public int? OrderPaymentMethodId { get; set; }
    public int? OrderShippingModeId { get; set; }

    public virtual IList<OrderDetailsMap> OrderDetailsMaps { get; set; } 

    public virtual IList<OrderHistoryMap> OrderHistoryMaps { get; set; } 
}
