using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class CategoryRequestModel
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Image { get; set; }

    public string? Status { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; } = new List<SubCategory>();
}
