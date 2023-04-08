using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class Shop
{
    public int ShopId { get; set; }
    public int AreaId { get; set; }

    public string ShopName { get; set; } = null!;

    public string PostCode { get; set; } = null!;

}
