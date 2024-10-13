using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int? Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
