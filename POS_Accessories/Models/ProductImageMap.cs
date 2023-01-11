using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class ProductImageMap
{
    public int ProductImageId { get; set; }

    public string ImageName { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public int ProductId { get; set; }

    public string ImageType { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual Product Product { get; set; } = null!;
}
