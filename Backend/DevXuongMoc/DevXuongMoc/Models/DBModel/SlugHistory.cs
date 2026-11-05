using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class SlugHistory
{
    public int Id { get; set; }

    public string EntityType { get; set; } = null!;

    public int EntityId { get; set; }

    public string OldSlug { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
