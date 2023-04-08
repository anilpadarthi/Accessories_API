using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class OrderHistoryMap
{
    public int OrderHistoryId { get; set; }

    public int OrderId { get; set; }

    public int? OrderStatusId { get; set; }

    public int? PaymentMethodId { get; set; }
    public int? ShippingModeId { get; set; }
    public bool? IsActive { get; set; }

    public string? Comments { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }
}
