using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; }
    public string? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

}
