using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class ContentBlock
{
    public int Id { get; set; }

    public byte ContentGroup { get; set; }

    public string Key { get; set; } = null!;

    public string? Title { get; set; }

    public string? BodyHtml { get; set; }

    public string? ImagePath { get; set; }

    public int SortOrder { get; set; }

    public bool IsVisible { get; set; }
}
