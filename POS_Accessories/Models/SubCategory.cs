using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class SubCategory
{
    public int SubCategoryId { get; set; }

    public string SubCategoryName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? Image { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual Category? Category { get; set; }
}
