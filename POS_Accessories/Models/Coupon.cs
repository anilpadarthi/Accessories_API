using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class Coupon
{
    public int CouponId { get; set; }

    public string CouponCode { get; set; } = null!;

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public bool IsActive { get; set; }

    public string? CouponType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }
}
