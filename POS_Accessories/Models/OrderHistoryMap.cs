using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class OrderHistoryMap
{
    public int OrderHistoryId { get; set; }

    public int OrderId { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string? PaymentMethod { get; set; }

    public bool? IsActive { get; set; }

    public string? Comments { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }
}
