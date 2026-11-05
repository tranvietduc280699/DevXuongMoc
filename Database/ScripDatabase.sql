CREATE DATABASE [XuongMoc]
ON PRIMARY
(
    NAME = N'XuongMoc_Data',
    FILENAME = N'D:\XuongMoc\Database\XuongMoc.mdf',
    SIZE = 64MB,
    FILEGROWTH = 64MB
)
LOG ON
(
    NAME = N'XuongMoc_Log',
    FILENAME = N'D:\XuongMoc\Database\XuongMoc_log.ldf',
    SIZE = 32MB,
    FILEGROWTH = 32MB
)
COLLATE Vietnamese_CI_AS;
GO

USE [XuongMoc];
GO

CREATE TABLE dbo.AspNetRoles
(
    Id                 NVARCHAR(36) NOT NULL,
    Name               NVARCHAR(256) NULL,
    NormalizedName     NVARCHAR(256) NULL,
    ConcurrencyStamp   NVARCHAR(MAX) NULL,
    CONSTRAINT PK_AspNetRoles PRIMARY KEY (Id)
);
GO
 
CREATE TABLE dbo.AspNetUsers                       
(
    Id                     NVARCHAR(36)  NOT NULL,
    FullName               NVARCHAR(200)  NOT NULL,
    IsActive               BIT            NOT NULL,
    UserName               NVARCHAR(256)  NULL,
    NormalizedUserName     NVARCHAR(256)  NULL,
    Email                  NVARCHAR(256)  NULL,
    NormalizedEmail        NVARCHAR(256)  NULL,
    EmailConfirmed         BIT            NOT NULL,
    PasswordHash           NVARCHAR(MAX)  NULL,
    SecurityStamp          NVARCHAR(MAX)  NULL,
    ConcurrencyStamp       NVARCHAR(MAX)  NULL,
    PhoneNumber            NVARCHAR(MAX)  NULL,
    PhoneNumberConfirmed   BIT            NOT NULL,
    TwoFactorEnabled       BIT            NOT NULL,
    LockoutEnd             DATETIMEOFFSET NULL,
    LockoutEnabled         BIT            NOT NULL,
    AccessFailedCount      INT            NOT NULL,
    CONSTRAINT PK_AspNetUsers PRIMARY KEY (Id)
);
GO
 
CREATE TABLE dbo.AspNetUserRoles
(
    UserId NVARCHAR(36) NOT NULL,
    RoleId NVARCHAR(36) NOT NULL, 
    CONSTRAINT PK_AspNetUserRoles PRIMARY KEY (UserId, RoleId),
    CONSTRAINT FK_AspNetUserRoles_Users FOREIGN KEY (UserId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT FK_AspNetUserRoles_Roles FOREIGN KEY (RoleId) REFERENCES dbo.AspNetRoles(Id)
);
GO
 
-- 3 role theo ma tran phan quyen (Khach = chua dang nhap, khong luu DB)
INSERT INTO dbo.AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES
 (N'role-admin',  N'Admin',  N'ADMIN',  CONVERT(NVARCHAR(36), NEWID())),
 (N'role-editor', N'Editor', N'EDITOR', CONVERT(NVARCHAR(36), NEWID())),
 (N'role-sales',  N'Sales',  N'SALES',  CONVERT(NVARCHAR(36), NEWID()));
GO
 
/* ===================== DANH MUC - SAN PHAM ===================== */
 -- Quản lý danh mục sản phẩm (ví dụ: Bàn ghế, Tủ quần áo, Giường ngủ, Kệ tivi...)
CREATE TABLE dbo.Category
(
    Id        INT IDENTITY(1,1) NOT NULL,
    Name      NVARCHAR(200) NOT NULL,
    Slug      NVARCHAR(250) NOT NULL,
    IconPath  NVARCHAR(500) NULL,
    SortOrder INT           NOT NULL,
    IsVisible BIT           NOT NULL,
    CONSTRAINT PK_Category PRIMARY KEY (Id)
);
GO
 -- thông tin chung
CREATE TABLE dbo.Product
(
    Id                 INT IDENTITY(1,1) NOT NULL,
    CategoryId         INT            NOT NULL,
    Name               NVARCHAR(250)  NOT NULL,
    Slug               NVARCHAR(300)  NOT NULL,
    ShortDescription   NVARCHAR(1000) NULL,
    WarrantyMonths     INT            NOT NULL,
    Rating             INT            NOT NULL,
    IsFeatured         BIT            NOT NULL,
    Status             TINYINT        NOT NULL,   
    ViewCount          INT            NOT NULL,
    IsDeleted          BIT            NOT NULL,  
    PublishedAt        DATETIME2(0)   NULL,
    CreatedAt          DATETIME2(0)   NOT NULL,   
    UpdatedAt          DATETIME2(0)   NULL,      
    CONSTRAINT PK_Product PRIMARY KEY (Id),
    CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryId) REFERENCES dbo.Category(Id)
);
GO
 -- Quản lý các biến thể theo chất liệu (Gỗ Sồi, Gỗ óc chó, Gỗ công nghiệp)
CREATE TABLE dbo.ProductVariant
(
    Id              INT IDENTITY(1,1) NOT NULL,
    ProductId       INT           NOT NULL,
    MaterialName    NVARCHAR(200) NOT NULL,
    OriginalPrice   DECIMAL(18,2) NOT NULL,
    SalePrice       DECIMAL(18,2) NULL,
    IsDefault       BIT           NOT NULL,
    SortOrder       INT           NOT NULL,
    CONSTRAINT PK_ProductVariant PRIMARY KEY (Id),
    CONSTRAINT FK_ProductVariant_Product FOREIGN KEY (ProductId) REFERENCES dbo.Product(Id)
);
GO
-- Quản lý danh sách hình ảnh minh họa cho từng sản phẩm
CREATE TABLE dbo.ProductImage
(
    Id        INT IDENTITY(1,1) NOT NULL,
    ProductId INT           NOT NULL,
    Path      NVARCHAR(500) NOT NULL,
    AltText   NVARCHAR(250) NULL,
    IsPrimary BIT           NOT NULL,
    SortOrder INT           NOT NULL,
    CONSTRAINT PK_ProductImage PRIMARY KEY (Id),
    CONSTRAINT FK_ProductImage_Product FOREIGN KEY (ProductId) REFERENCES dbo.Product(Id)
);
GO
 -- Lưu lịch sử thay đổi đường dẫn
CREATE TABLE dbo.SlugHistory
(
    Id           INT IDENTITY(1,1) NOT NULL,
    EntityType   NVARCHAR(50)  NOT NULL,  
    EntityId     INT           NOT NULL,
    OldSlug      NVARCHAR(350) NOT NULL,
    CreatedAt    DATETIME2(0)  NOT NULL,  
    CONSTRAINT PK_SlugHistory PRIMARY KEY (Id)
);
GO
 
/* ===================== NOI DUNG ===================== */
 --Quản lý các banner quảng cáo, slide hình ảnh chạy trên website
 -- (tiêu đề, hình ảnh, đường dẫn liên kết, vị trí hiển thị và thời gian bắt đầu/kết thúc)
CREATE TABLE dbo.Banner
(
    Id        INT IDENTITY(1,1) NOT NULL,
    Title     NVARCHAR(250) NOT NULL,
    Subtitle  NVARCHAR(500) NULL,
    ImagePath NVARCHAR(500) NOT NULL,
    LinkUrl   NVARCHAR(500) NULL,
    Placement TINYINT       NOT NULL,   
    StartsAt  DATETIME2(0)  NULL,
    EndsAt    DATETIME2(0)  NULL,
    IsActive  BIT           NOT NULL,
    CONSTRAINT PK_Banner PRIMARY KEY (Id)
);
GO
 -- Quản lý danh sách đối tác (Logo, website, mô tả)
CREATE TABLE dbo.Partner
(
    Id            INT IDENTITY(1,1) NOT NULL,
    Name          NVARCHAR(250)  NOT NULL,
    Description   NVARCHAR(1000) NULL,
    LogoPath      NVARCHAR(500)  NULL,
    WebsiteUrl    NVARCHAR(500)  NULL,
    ShowOnHome    BIT            NOT NULL,
    IsVisible     BIT            NOT NULL,
    CONSTRAINT PK_Partner PRIMARY KEY (Id)
);
GO
 -- Lưu trữ các khối nội dung tĩnh
CREATE TABLE dbo.ContentBlock
(
    Id             INT IDENTITY(1,1) NOT NULL,
    ContentGroup   TINYINT       NOT NULL,   
    [Key]          NVARCHAR(100) NOT NULL,
    Title          NVARCHAR(250) NULL,
    BodyHtml       NVARCHAR(MAX) NULL,
    ImagePath      NVARCHAR(500) NULL,
    SortOrder      INT           NOT NULL,
    IsVisible      BIT           NOT NULL,
    CONSTRAINT PK_ContentBlock PRIMARY KEY (Id)
);
GO
 -- Quản lý các bài viết tin tức, blog, chia sẻ kinh nghiệm
CREATE TABLE dbo.Article
(
    Id            INT IDENTITY(1,1) NOT NULL,
    AuthorId      NVARCHAR(36)   NOT NULL,   
    Title         NVARCHAR(300)  NOT NULL,
    Slug          NVARCHAR(350)  NOT NULL,
    Summary       NVARCHAR(1000) NULL,
    BodyHtml      NVARCHAR(MAX)  NULL,
    CoverImage    NVARCHAR(500)  NULL,
    Status        TINYINT        NOT NULL,   
    PublishedAt   DATETIME2(0)   NULL,
    ViewCount     INT            NOT NULL,
    CreatedAt     DATETIME2(0)   NOT NULL,   
    UpdatedAt     DATETIME2(0)   NULL,      
    CONSTRAINT PK_Article PRIMARY KEY (Id),
    CONSTRAINT FK_Article_Author FOREIGN KEY (AuthorId) REFERENCES dbo.AspNetUsers(Id)
);
GO
 
/* ===================== LIEN HE - HE THONG ===================== */
 -- Lưu trữ các yêu cầu liên hệ, báo giá hoặc đặt làm
CREATE TABLE dbo.ContactRequest
(
    Id                 INT IDENTITY(1,1) NOT NULL,
    Type               TINYINT        NOT NULL,   
    FullName           NVARCHAR(200)  NOT NULL,
    Email              NVARCHAR(256)  NULL,
    Phone              NVARCHAR(30)   NULL,
    Message            NVARCHAR(2000) NULL,
    MaterialName       NVARCHAR(200)  NULL,
    Status             TINYINT        NOT NULL,   
    IpAddress          NVARCHAR(45)   NULL,
    FirstViewedAt      DATETIME2(0)   NULL,
    ClosedAt           DATETIME2(0)   NULL,
    RowVersion         ROWVERSION     NOT NULL,
    ProductId          INT            NULL,
    AssignedToId       NVARCHAR(36)   NULL,      
    IsHidden           BIT            NOT NULL,   
    CreatedAt          DATETIME2(0)   NOT NULL,  
    CONSTRAINT PK_ContactRequest PRIMARY KEY (Id),
    CONSTRAINT FK_ContactRequest_Product  FOREIGN KEY (ProductId)        REFERENCES dbo.Product(Id),
    CONSTRAINT FK_ContactRequest_Assignee FOREIGN KEY (AssignedToId) REFERENCES dbo.AspNetUsers(Id)
);
GO
 -- Lưu các ghi chú trao đổi nội bộ hoặc lịch sử xử lý của nhân viên đối với một yêu cầu liên hệ
CREATE TABLE dbo.ContactRequestNote
(
    Id                 INT IDENTITY(1,1) NOT NULL,
    ContactRequestId   INT            NOT NULL,
    Content            NVARCHAR(2000) NOT NULL,
    IsSystem           BIT            NOT NULL,
    CreatedByUserId    NVARCHAR(36)   NULL,       
    CreatedAt          DATETIME2(0)   NOT NULL,  
    CONSTRAINT PK_ContactRequestNote PRIMARY KEY (Id),
    CONSTRAINT FK_ContactRequestNote_Request FOREIGN KEY (ContactRequestId) REFERENCES dbo.ContactRequest(Id),
    CONSTRAINT FK_ContactRequestNote_User    FOREIGN KEY (CreatedByUserId)  REFERENCES dbo.AspNetUsers(Id)
);
GO
 -- Ghi lại lịch sử thao tác quan trọng của người dùng trên hệ thống
CREATE TABLE dbo.AuditLog
(
    Id           BIGINT IDENTITY(1,1) NOT NULL,
    UserId       NVARCHAR(36)   NULL,      
    Action       NVARCHAR(100)  NOT NULL,
    EntityName   NVARCHAR(100)  NOT NULL,
    EntityId     NVARCHAR(100)  NULL,
    Summary      NVARCHAR(1000) NULL,
    IpAddress    NVARCHAR(45)   NULL,
    CreatedAt    DATETIME2(0)   NOT NULL,  
    CONSTRAINT PK_AuditLog PRIMARY KEY (Id),
    CONSTRAINT FK_AuditLog_User FOREIGN KEY (UserId) REFERENCES dbo.AspNetUsers(Id)
);
GO
 -- Lưu trữ các cấu hình chung của toàn website dạng khóa-giá trị
CREATE TABLE dbo.SiteSetting
(
    [Key]   NVARCHAR(100) NOT NULL,
    [Value] NVARCHAR(MAX) NULL,
    CONSTRAINT PK_SiteSetting PRIMARY KEY ([Key])
);
GO
 -- Quản lý kho lưu trữ tệp tin/hình ảnh
CREATE TABLE dbo.MediaFile
(
    Id           INT IDENTITY(1,1) NOT NULL,
    Path         NVARCHAR(500) NOT NULL,
    SizeBytes    BIGINT        NOT NULL,
    Width        INT           NULL,
    Height       INT           NULL,
    OrphanedAt   DATETIME2(0)  NULL,
    CreatedAt    DATETIME2(0)  NOT NULL,   -- [THEM]
    CONSTRAINT PK_MediaFile PRIMARY KEY (Id)
);
GO
 -- Hàng đợi gửi email
CREATE TABLE dbo.EmailOutbox
(
    Id          INT IDENTITY(1,1) NOT NULL,
    Status      TINYINT        NOT NULL,   -- vd: 0=Cho gui, 1=Da gui, 2=Loi
    Attempts    INT            NOT NULL,
    ToEmail     NVARCHAR(256)  NOT NULL,   
    Subject     NVARCHAR(300)  NOT NULL,   
    BodyHtml    NVARCHAR(MAX)  NULL,       
    LastError   NVARCHAR(1000) NULL,      
    CreatedAt   DATETIME2(0)   NOT NULL,  
    SentAt      DATETIME2(0)   NULL,      
    CONSTRAINT PK_EmailOutbox PRIMARY KEY (Id)
);
GO
 
PRINT N'Tao database XuongMoc thanh cong.';
GO