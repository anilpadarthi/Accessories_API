using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public int ProductId { get; set; }

    public int Available { get; set; }

    public int Sold { get; set; }

    public int TotalAdded { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
