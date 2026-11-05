using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class ProductVariant
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string MaterialName { get; set; } = null!;

    public decimal OriginalPrice { get; set; }

    public decimal? SalePrice { get; set; }

    public bool IsDefault { get; set; }

    public int SortOrder { get; set; }

    public virtual Product Product { get; set; } = null!;
}
