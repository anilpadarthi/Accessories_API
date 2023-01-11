using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class CouponMap
{
    public int CouponMapId { get; set; }

    public int CouponId { get; set; }

    public int ShopId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }
}
