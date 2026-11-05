using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? ShortDescription { get; set; }

    public int WarrantyMonths { get; set; }

    public int Rating { get; set; }

    public bool IsFeatured { get; set; }

    public byte Status { get; set; }

    public int ViewCount { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ContactRequest> ContactRequests { get; set; } = new List<ContactRequest>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
