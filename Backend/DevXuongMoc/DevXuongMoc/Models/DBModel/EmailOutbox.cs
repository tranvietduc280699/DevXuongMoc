using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class EmailOutbox
{
    public int Id { get; set; }

    public byte Status { get; set; }

    public int Attempts { get; set; }

    public string ToEmail { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string? BodyHtml { get; set; }

    public string? LastError { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? SentAt { get; set; }
}
