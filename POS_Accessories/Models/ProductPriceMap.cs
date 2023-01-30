using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class ProductPriceMap
{
    public int ProductPriceMapId { get; set; }

    public decimal SalePrice { get; set; }

    public int ProductId { get; set; }

    public int FromQty { get; set; }

    public int? ToQty { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual Product Product { get; set; } = null!;
}
