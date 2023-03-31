﻿using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class OrderDeliveryType
{
    public int OrderDeliveryTypeId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }
}
