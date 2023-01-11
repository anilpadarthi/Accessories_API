using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class StockAllocation
{
    public int StockAllocatationId { get; set; }

    public int ProductId { get; set; }

    public int TotalAllocated { get; set; }

    public int TotalSold { get; set; }

    public int UserId { get; set; }

    public DateTime? Doa { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }
}
