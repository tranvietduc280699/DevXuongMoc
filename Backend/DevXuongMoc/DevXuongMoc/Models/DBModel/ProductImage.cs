using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Path { get; set; } = null!;

    public string? AltText { get; set; }

    public bool IsPrimary { get; set; }

    public int SortOrder { get; set; }

    public virtual Product Product { get; set; } = null!;
}
