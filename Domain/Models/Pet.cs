using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Pet
{
    public int PetId { get; set; }

    public string? PetName { get; set; }

    public int CategoryId { get; set; }

    public int? Age { get; set; }

    public decimal? Price { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public int? BreedId { get; set; }

    public virtual Breed? Breed { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual User? UpdatedByNavigation { get; set; }
}
