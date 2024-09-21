using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class DiscountUsage
{
    public int DiscountUsageId { get; set; }

    public int DiscountId { get; set; }

    public int UserId { get; set; }

    public DateTime? UsedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Discount Discount { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
