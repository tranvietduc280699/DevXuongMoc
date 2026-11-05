using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class Partner
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? LogoPath { get; set; }

    public string? WebsiteUrl { get; set; }

    public bool ShowOnHome { get; set; }

    public bool IsVisible { get; set; }
}
