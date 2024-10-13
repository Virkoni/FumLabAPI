using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PlushPartCategory
{
    public int PartCategoryId { get; set; }

    public string PartCategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<PlushPart> PlushParts { get; set; } = new List<PlushPart>();
}
