using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Artist> ArtistCreatedByNavigations { get; set; } = new List<Artist>();

    public virtual ICollection<Artist> ArtistUpdatedByNavigations { get; set; } = new List<Artist>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<CustomPlushOrder> CustomPlushOrders { get; set; } = new List<CustomPlushOrder>();

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PlushPart> PlushPartCreatedByNavigations { get; set; } = new List<PlushPart>();

    public virtual ICollection<PlushPart> PlushPartUpdatedByNavigations { get; set; } = new List<PlushPart>();

    public virtual ICollection<Product> ProductCreatedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductUpdatedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}