using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class AuditLog
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string Action { get; set; } = null!;

    public string EntityName { get; set; } = null!;

    public string? EntityId { get; set; }

    public string? Summary { get; set; }

    public string? IpAddress { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual AspNetUser? User { get; set; }
}
