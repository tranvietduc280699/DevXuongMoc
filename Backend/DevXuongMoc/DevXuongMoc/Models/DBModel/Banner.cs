using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class Banner
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Subtitle { get; set; }

    public string ImagePath { get; set; } = null!;

    public string? LinkUrl { get; set; }

    public byte Placement { get; set; }

    public DateTime? StartsAt { get; set; }

    public DateTime? EndsAt { get; set; }

    public bool IsActive { get; set; }
}
