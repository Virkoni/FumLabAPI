using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category Category { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductArtist> ProductArtists { get; set; } = new List<ProductArtist>();

    public virtual ICollection<ProductAvailability> ProductAvailabilities { get; set; } = new List<ProductAvailability>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual User? UpdatedByNavigation { get; set; }
}
