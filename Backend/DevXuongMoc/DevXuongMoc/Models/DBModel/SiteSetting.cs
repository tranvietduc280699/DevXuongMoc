using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class SiteSetting
{
    public string Key { get; set; } = null!;

    public string? Value { get; set; }
}
