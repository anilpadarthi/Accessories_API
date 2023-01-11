﻿using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class Size
{
    public int SizeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<ProductSizeMap> ProductSizeMaps { get; } = new List<ProductSizeMap>();
}
