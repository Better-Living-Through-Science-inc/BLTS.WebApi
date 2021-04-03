using BLTS.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BLTS.WebApi.Infrastructure.Database
{
    public class WebDbContext : DbContext
    {
        public virtual DbSet<ApplicationLog> ApplicationLogs { get; set; }
        public virtual DbSet<FileStorage> FileStorages { get; set; }
        public virtual DbSet<NavigationMenu> NavigationMenus { get; set; }
        public virtual DbSet<NavigationMenuNavigationMenu> NavigationMenuNavigationMenus { get; set; }
        public virtual DbSet<OperationalConfiguration> OperationalConfigurations { get; set; }
        public virtual DbSet<WebpageContent> WebpageContents { get; set; }
        public virtual DbSet<Website> Websites { get; set; }
        public virtual DbSet<WebsiteNavigationMenu> WebsiteNavigationMenus { get; set; }

        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicationLog>(entity =>
            {
                entity.ToTable("ApplicationLog", "Log");

                entity.Property(e => e.Id).HasColumnName("ApplicationLogId");

                entity.HasKey(e => new { e.Id, e.CreationDate });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.EnvironmentName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ExceptionStacktrace).HasMaxLength(4000);

                entity.Property(e => e.ExecutionDuration).HasDefaultValueSql("((-5555))");

                entity.Property(e => e.ExecutionTime).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.MethodName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NotificationDate).HasDefaultValueSql("(CONVERT([datetime2](7),'9999-12-31',(0)))");

                entity.HasOne(d => d.Website)
                    .WithMany(p => p.ApplicationLogCollection)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemStatusLog_Website");
            });

            modelBuilder.Entity<FileStorage>(entity =>
            {
                entity.ToTable("FileStorage", "dbo");

                entity.Property(e => e.Id).HasColumnName("FileStorageId");

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.RootPath)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SizeKB).HasColumnName("SizeKB");

                entity.Property(e => e.SubPath)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<NavigationMenu>(entity =>
            {
                entity.ToTable("NavigationMenu", "dbo");

                entity.Property(e => e.Id).HasColumnName("NavigationMenuId");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.DisplayText)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IconClass)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.SubPath)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ToolTip)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.WebpageContent)
                    .WithMany(p => p.NavigationMenuCollection)
                    .HasForeignKey(d => d.WebpageContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NavigationMenu_WebpageContent");
            });

            modelBuilder.Entity<NavigationMenuNavigationMenu>(entity =>
            {
                entity.ToTable("NavigationMenuNavigationMenu", "dbo");

                entity.HasKey(e => new { e.ParentNavigationMenuId, e.ChildNavigationMenuId });

                entity.HasOne(d => d.ChildNavigationMenu)
                    .WithMany(p => p.NavigationMenuNavigationMenuChildNavigationMenuCollection)
                    .HasForeignKey(d => d.ChildNavigationMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NavigationMenuNavigationMenu_NavigationMenu1");

                entity.HasOne(d => d.ParentNavigationMenu)
                    .WithMany(p => p.NavigationMenuNavigationMenuParentNavigationMenuCollection)
                    .HasForeignKey(d => d.ParentNavigationMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NavigationMenuNavigationMenu_NavigationMenu");
            });

            modelBuilder.Entity<OperationalConfiguration>(entity =>
            {
                entity.ToTable("OperationalConfiguration", "dbo");

                entity.Property(e => e.Id).HasColumnName("OperationalConfigurationId");

                entity.HasIndex(e => e.PropertyName, "UX_OperationalConfiguration_PropertyName")
                    .IsUnique()
                    .HasFillFactor((byte)90);

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.DecimalValue).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Website)
                    .WithMany(p => p.OperationalConfigurationCollection)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperationalConfiguration_Website");
            });

            modelBuilder.Entity<WebpageContent>(entity =>
            {
                entity.ToTable("WebpageContent", "dbo");

                entity.Property(e => e.Id).HasColumnName("WebpageContentId");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Metatag).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Website>(entity =>
            {
                entity.ToTable("Website", "dbo");

                entity.Property(e => e.Id).HasColumnName("WebsiteId");

                entity.Property(e => e.BaseUrl)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.CssThemePath).HasMaxLength(255);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Footer).IsRequired();

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Metatag)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PocEmail).HasMaxLength(255);

                entity.Property(e => e.PocNumber).HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WebsiteNavigationMenu>(entity =>
            {
                entity.ToTable("WebsiteNavigationMenu", "dbo");

                entity.HasKey(e => new { e.WebsiteId, e.NavigationMenuId });

                entity.HasOne(d => d.NavigationMenu)
                    .WithMany(p => p.WebsiteNavigationMenuCollection)
                    .HasForeignKey(d => d.NavigationMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebsiteNavigationMenu_NavigationMenu");

                entity.HasOne(d => d.Website)
                    .WithMany(p => p.WebsiteNavigationMenuCollection)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebsiteNavigationMenu_Website");
            });

            base.OnModelCreating(modelBuilder);
            /*Seed the DB*/
            WebDbContextBuilderExtensions.Seed(modelBuilder);
        }



    }
}

