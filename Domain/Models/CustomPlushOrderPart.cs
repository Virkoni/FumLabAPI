using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CustomPlushOrderPart
{
    public int CustomOrderPartId { get; set; }

    public int CustomOrderId { get; set; }

    public int PartId { get; set; }

    public int Quantity { get; set; }

    public DateTime? AddedAt { get; set; }

    public virtual CustomPlushOrder CustomOrder { get; set; } = null!;

    public virtual PlushPart Part { get; set; } = null!;
}