using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string ArtistName { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<ProductArtist> ProductArtists { get; set; } = new List<ProductArtist>();

    public virtual User? UpdatedByNavigation { get; set; }
}
