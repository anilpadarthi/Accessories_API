using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class ProductBundleMap
{
    public int ProductBundleId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal SalePrice { get; set; }

    public bool IsActive { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int ModifiedBy { get; set; }

    public virtual Product Product { get; set; } = null!;
}
