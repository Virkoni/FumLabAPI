using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ProductAvailability
{
    public int AvailabilityId { get; set; }

    public int ProductId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Product Product { get; set; } = null!;
}