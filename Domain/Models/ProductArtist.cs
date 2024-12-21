using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ProductArtist
{
    public int ProductArtistId { get; set; }

    public int ProductId { get; set; }

    public int ArtistId { get; set; }

    public DateTime? AssignedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}