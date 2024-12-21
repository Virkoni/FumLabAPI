using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CustomPlushOrder
{
    public int CustomOrderId { get; set; }

    public int UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime? OrderDate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<CustomPlushOrderPart> CustomPlushOrderParts { get; set; } = new List<CustomPlushOrderPart>();

    public virtual User User { get; set; } = null!;
}