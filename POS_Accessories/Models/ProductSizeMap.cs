﻿using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class ProductSizeMap
{
    public int ProductSizeId { get; set; }

    public int SizeId { get; set; }

    public int ProductId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifedBy { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}
