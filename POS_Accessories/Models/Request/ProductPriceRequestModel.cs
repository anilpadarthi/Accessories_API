using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class ProductPriceRequestModel
{
    public int? ProductPriceMapId { get; set; }
    public int? ProductId { get; set; }
    public decimal? SalePrice { get; set; }   
    public int? FromQty { get; set; }
    public int? ToQty { get; set; }
    public bool? IsActive { get; set; }

}
