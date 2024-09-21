using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Breed
{
    public int BreedId { get; set; }

    public string BreedName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
