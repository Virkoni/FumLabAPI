using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PlushPart
{
    public int PartId { get; set; }

    public string PartName { get; set; } = null!;

    public int PartCategoryId { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<CustomPlushOrderPart> CustomPlushOrderParts { get; set; } = new List<CustomPlushOrderPart>();

    public virtual PlushPartCategory PartCategory { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}