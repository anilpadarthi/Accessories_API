using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class StockAllocationHistory
{
    public int StockAllocationHistoryId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime Doa { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public string? AllocationType { get; set; }
}
