using System;
using System.Collections.Generic;

namespace POS_Accessories.Models;

public partial class Configuration
{
    public int ConfigId { get; set; }
    public int ConfigurationTypeId { get; set; }
    public decimal? Amount { get; set; }
    public bool? IsActive { get; set; }
    public string? Status { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
}
