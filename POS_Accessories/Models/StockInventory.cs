using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class StockInventory
{
    public int StockInventoryId { get; set; }

    public int ProductId { get; set; }

    public int Qty { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public decimal? BuyPrice { get; set; }

    public int? SupplierId { get; set; }

    public string? InvoiceNumber { get; set;}

    public string? Status { get; set; }
}
