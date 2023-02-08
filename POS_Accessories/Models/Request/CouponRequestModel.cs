using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class CouponRequestModel
{
    public int CouponId { get; set; }

    public string CouponCode { get; set; } = null!;
    public string Description { get; set; } = null!;

    public string ValidFrom { get; set; }

    public string ValidTo { get; set; }

    public string? Status { get; set; }

    public string? CouponType { get; set; }

}
