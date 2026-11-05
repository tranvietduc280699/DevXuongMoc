using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class MediaFile
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public long SizeBytes { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public DateTime? OrphanedAt { get; set; }

    public DateTime CreatedAt { get; set; }
}
