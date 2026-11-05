using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models.DBModel;

public partial class Article
{
    public int Id { get; set; }

    public string AuthorId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Summary { get; set; }

    public string? BodyHtml { get; set; }

    public string? CoverImage { get; set; }

    public byte Status { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int ViewCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual AspNetUser Author { get; set; } = null!;
}
