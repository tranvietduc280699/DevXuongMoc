using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class ContactRequestNote
{
    public int Id { get; set; }

    public int ContactRequestId { get; set; }

    public string Content { get; set; } = null!;

    public bool IsSystem { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ContactRequest ContactRequest { get; set; } = null!;

    public virtual AspNetUser? CreatedByUser { get; set; }
}
