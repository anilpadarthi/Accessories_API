using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class Product
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
    public bool? IsVatEnabled { get; set; }
    public bool? IsOutOfStock { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
    public virtual ICollection<ProductBundleMap> ProductBundleMaps { get; } = new List<ProductBundleMap>();

    public virtual ICollection<ProductColourMap> ProductColourMaps { get; } = new List<ProductColourMap>();

    public virtual ICollection<ProductImageMap> ProductImageMaps { get; } = new List<ProductImageMap>();

    public virtual ICollection<ProductPriceMap> ProductPriceMaps { get; } = new List<ProductPriceMap>();

    public virtual ICollection<ProductSizeMap> ProductSizeMaps { get; } = new List<ProductSizeMap>();
}
