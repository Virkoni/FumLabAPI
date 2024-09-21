using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime? LastUpdated { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Product Product { get; set; } = null!;
}
