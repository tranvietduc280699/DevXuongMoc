using DevXuongMoc.Models.DBModel;
using Microsoft.EntityFrameworkCore;

namespace DevXuongMoc.Data;

public partial class XuongMocContext : DbContext
{
    public XuongMocContext()
    {
    }

    public XuongMocContext(DbContextOptions<XuongMocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ContactRequest> ContactRequests { get; set; }

    public virtual DbSet<ContactRequestNote> ContactRequestNotes { get; set; }

    public virtual DbSet<ContentBlock> ContentBlocks { get; set; }

    public virtual DbSet<EmailOutbox> EmailOutboxes { get; set; }

    public virtual DbSet<MediaFile> MediaFiles { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<SiteSetting> SiteSettings { get; set; }

    public virtual DbSet<SlugHistory> SlugHistories { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=XuongMoc;Trusted_Connection=True;MultipleActiveResultSets=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Vietnamese_CI_AS");

        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("Article");

            entity.Property(e => e.AuthorId).HasMaxLength(36);
            entity.Property(e => e.CoverImage).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.PublishedAt).HasPrecision(0);
            entity.Property(e => e.Slug).HasMaxLength(350);
            entity.Property(e => e.Summary).HasMaxLength(1000);
            entity.Property(e => e.Title).HasMaxLength(300);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Author).WithMany(p => p.Articles)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Article_Author");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AspNetUserRoles_Roles"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AspNetUserRoles_Users"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.IndexerProperty<string>("UserId").HasMaxLength(36);
                        j.IndexerProperty<string>("RoleId").HasMaxLength(36);
                    });
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.ToTable("AuditLog");

            entity.Property(e => e.Action).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.EntityId).HasMaxLength(100);
            entity.Property(e => e.EntityName).HasMaxLength(100);
            entity.Property(e => e.IpAddress).HasMaxLength(45);
            entity.Property(e => e.Summary).HasMaxLength(1000);
            entity.Property(e => e.UserId).HasMaxLength(36);

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AuditLog_User");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.ToTable("Banner");

            entity.Property(e => e.EndsAt).HasPrecision(0);
            entity.Property(e => e.ImagePath).HasMaxLength(500);
            entity.Property(e => e.LinkUrl).HasMaxLength(500);
            entity.Property(e => e.StartsAt).HasPrecision(0);
            entity.Property(e => e.Subtitle).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.IconPath).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Slug).HasMaxLength(250);
        });

        modelBuilder.Entity<ContactRequest>(entity =>
        {
            entity.ToTable("ContactRequest");

            entity.Property(e => e.AssignedToId).HasMaxLength(36);
            entity.Property(e => e.ClosedAt).HasPrecision(0);
            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstViewedAt).HasPrecision(0);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.IpAddress).HasMaxLength(45);
            entity.Property(e => e.MaterialName).HasMaxLength(200);
            entity.Property(e => e.Message).HasMaxLength(2000);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssignedTo).WithMany(p => p.ContactRequests)
                .HasForeignKey(d => d.AssignedToId)
                .HasConstraintName("FK_ContactRequest_Assignee");

            entity.HasOne(d => d.Product).WithMany(p => p.ContactRequests)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ContactRequest_Product");
        });

        modelBuilder.Entity<ContactRequestNote>(entity =>
        {
            entity.ToTable("ContactRequestNote");

            entity.Property(e => e.Content).HasMaxLength(2000);
            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.CreatedByUserId).HasMaxLength(36);

            entity.HasOne(d => d.ContactRequest).WithMany(p => p.ContactRequestNotes)
                .HasForeignKey(d => d.ContactRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactRequestNote_Request");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.ContactRequestNotes)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK_ContactRequestNote_User");
        });

        modelBuilder.Entity<ContentBlock>(entity =>
        {
            entity.ToTable("ContentBlock");

            entity.Property(e => e.ImagePath).HasMaxLength(500);
            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<EmailOutbox>(entity =>
        {
            entity.ToTable("EmailOutbox");

            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.LastError).HasMaxLength(1000);
            entity.Property(e => e.SentAt).HasPrecision(0);
            entity.Property(e => e.Subject).HasMaxLength(300);
            entity.Property(e => e.ToEmail).HasMaxLength(256);
        });

        modelBuilder.Entity<MediaFile>(entity =>
        {
            entity.ToTable("MediaFile");

            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.OrphanedAt).HasPrecision(0);
            entity.Property(e => e.Path).HasMaxLength(500);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.ToTable("Partner");

            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.LogoPath).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.WebsiteUrl).HasMaxLength(500);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.PublishedAt).HasPrecision(0);
            entity.Property(e => e.ShortDescription).HasMaxLength(1000);
            entity.Property(e => e.Slug).HasMaxLength(300);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.ToTable("ProductImage");

            entity.Property(e => e.AltText).HasMaxLength(250);
            entity.Property(e => e.Path).HasMaxLength(500);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImage_Product");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.ToTable("ProductVariant");

            entity.Property(e => e.MaterialName).HasMaxLength(200);
            entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductVariant_Product");
        });

        modelBuilder.Entity<SiteSetting>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.ToTable("SiteSetting");

            entity.Property(e => e.Key).HasMaxLength(100);
        });

        modelBuilder.Entity<SlugHistory>(entity =>
        {
            entity.ToTable("SlugHistory");

            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.EntityType).HasMaxLength(50);
            entity.Property(e => e.OldSlug).HasMaxLength(350);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
