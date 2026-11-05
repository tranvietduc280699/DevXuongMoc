using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class ContactRequest
{
    public int Id { get; set; }

    public byte Type { get; set; }

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Message { get; set; }

    public string? MaterialName { get; set; }

    public byte Status { get; set; }

    public string? IpAddress { get; set; }

    public DateTime? FirstViewedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public int? ProductId { get; set; }

    public string? AssignedToId { get; set; }

    public bool IsHidden { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual AspNetUser? AssignedTo { get; set; }

    public virtual ICollection<ContactRequestNote> ContactRequestNotes { get; set; } = new List<ContactRequestNote>();

    public virtual Product? Product { get; set; }
}
