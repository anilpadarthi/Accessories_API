using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class ProductRequestModel
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductCode { get; set; }

    public int? CategoryId { get; set; }

    public int? SubCategoryId { get; set; }

    public string? Description { get; set; }

    public string? Specification { get; set; }

    public bool? IsNewArrival { get; set; }

    public bool? IsBundle { get; set; }
    public bool? IsOutOfStock { get; set; }

    public bool? IsVatEnabled { get; set; }

    public string? Status { get; set; }
    public List<int> SizeList { get; set; }
    public List<int> ColourList { get; set; }
    public List<ProductPriceRequestModel> PriceList { get; set; }

}
