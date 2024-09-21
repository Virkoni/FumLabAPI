using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public string? DiscountName { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<DiscountUsage> DiscountUsages { get; set; } = new List<DiscountUsage>();
}
