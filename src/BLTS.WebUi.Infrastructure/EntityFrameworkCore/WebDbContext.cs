using BLTS.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BLTS.WebApi.Infrastructure.Database
{
    public class WebDbContext : DbContext
    {
        public WebDbContext()
        {
        }

        public WebDbContext(DbContextOptions<WebDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveDirectoryGroup> ActiveDirectoryGroups { get; set; }
        public virtual DbSet<ApplicationInfo> ApplicationInfos { get; set; }
        public virtual DbSet<ApplicationLog> ApplicationLogs { get; set; }
        public virtual DbSet<ApplicationPermission> ApplicationPermissions { get; set; }
        public virtual DbSet<FileStorage> FileStorages { get; set; }
        public virtual DbSet<FileStoragePermission> FileStoragePermissions { get; set; }
        public virtual DbSet<NavigationMenu> NavigationMenus { get; set; }
        public virtual DbSet<OperationalConfiguration> OperationalConfigurations { get; set; }
        public virtual DbSet<WebpageContent> WebpageContents { get; set; }
        public virtual DbSet<WebpageContentPermission> WebpageContentPermissions { get; set; }
        public virtual DbSet<WebsiteInfo> WebsiteInfos { get; set; }
        public virtual DbSet<WebsiteNavigationMenu> WebsiteNavigationMenus { get; set; }
        public virtual DbSet<WebsitePermission> WebsitePermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ActiveDirectoryGroup>(entity =>
            {
                entity.ToTable("ActiveDirectoryGroup", "dbo");

                entity.Property(e => e.Id).HasColumnName("ActiveDirectoryGroupId");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.GroupSid)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ApplicationInfo>(entity =>
            {
                entity.ToTable("ApplicationInfo", "dbo");

                entity.Property(e => e.Id).HasColumnName("ApplicationInfoId");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PocEmail).HasMaxLength(255);

                entity.Property(e => e.PocNumber).HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ApplicationLog>(entity =>
            {
                entity.ToTable("ApplicationLog", "Log");

                entity.Property(e => e.Id).HasColumnName("ApplicationLogId");

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

                entity.HasOne(d => d.ApplicationInfo)
                    .WithMany(p => p.ApplicationLogCollection)
                    .HasForeignKey(d => d.ApplicationInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationLog_Application");
            });

            modelBuilder.Entity<ApplicationPermission>(entity =>
            {
                entity.ToTable("ApplicationPermission", "dbo");

                entity.Property(e => e.Id).HasColumnName("ApplicationPermissionId");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.HasOne(d => d.ActiveDirectoryGroup)
                    .WithMany(p => p.ApplicationPermissionCollection)
                    .HasForeignKey(d => d.ActiveDirectoryGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationPermission_ActiveDirectoryGroup");

                entity.HasOne(d => d.ApplicationInfo)
                    .WithMany(p => p.ApplicationPermissionCollection)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationPermission_Application");
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

            modelBuilder.Entity<FileStoragePermission>(entity =>
            {
                entity.ToTable("FileStoragePermission", "dbo");

                entity.Property(e => e.Id).HasColumnName("FileStoragePermissionId");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.HasOne(d => d.ActiveDirectoryGroup)
                    .WithMany(p => p.FileStoragePermissionCollection)
                    .HasForeignKey(d => d.ActiveDirectoryGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileStoragePermission_ActiveDirectoryGroup");

                entity.HasOne(d => d.FileStorage)
                    .WithMany(p => p.FileStoragePermissionCollection)
                    .HasForeignKey(d => d.FileStorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileStoragePermission_FileStorage");
            });

            modelBuilder.Entity<NavigationMenu>(entity =>
            {
                entity.ToTable("NavigationMenu", "dbo");

                entity.Property(e => e.Id).HasColumnName("NavigationMenuId");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.ParentNavigationMenuId)
                    .IsRequired()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NavLinkText)
                    .IsRequired()
                    .HasMaxLength(255);

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

                entity.HasOne(d => d.ParentNavigationMenu)
                    .WithMany(p => p.ChildNavigationMenuCollection)
                    .HasForeignKey(d => d.ParentNavigationMenuId)
                    .HasConstraintName("FK_NavigationMenu_NavigationMenu");

                entity.HasOne(d => d.WebpageContent)
                    .WithMany(p => p.NavigationMenuCollection)
                    .HasForeignKey(d => d.WebpageContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NavigationMenu_WebpageContent");
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

                entity.HasOne(d => d.ApplicationInfo)
                    .WithMany(p => p.OperationalConfigurationCollection)
                    .HasForeignKey(d => d.ApplicationInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperationalConfiguration_Application");
            });

            modelBuilder.Entity<WebpageContent>(entity =>
            {
                entity.ToTable("WebpageContent", "dbo");

                entity.Property(e => e.Id).HasColumnName("WebpageContentId");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Metatag).HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WebpageContentPermission>(entity =>
            {
                entity.ToTable("WebpageContentPermission", "dbo");

                entity.Property(e => e.Id).HasColumnName("WebpageContentPermissionId");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.HasOne(d => d.ActiveDirectoryGroup)
                    .WithMany(p => p.WebpageContentPermissionCollection)
                    .HasForeignKey(d => d.ActiveDirectoryGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebpageContentPermission_ActiveDirectoryGroup");

                entity.HasOne(d => d.WebpageContent)
                    .WithMany(p => p.WebpageContentPermissionCollection)
                    .HasForeignKey(d => d.WebpageContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebpageContentPermission_WebpageContent");
            });

            modelBuilder.Entity<WebsiteInfo>(entity =>
            {
                entity.ToTable("WebsiteInfo", "dbo");

                entity.Property(e => e.Id).HasColumnName("WebsiteInfoId");

                entity.Property(e => e.BaseUrl)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.CssThemePath).HasMaxLength(255);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Footer).IsRequired();

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Metatag)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.ApplicationInfo)
                    .WithMany(p => p.WebsiteInfoCollection)
                    .HasForeignKey(d => d.ApplicationInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Website_Application");
            });

            modelBuilder.Entity<WebsitePermission>(entity =>
            {
                entity.ToTable("WebsitePermission", "dbo");

                entity.Property(e => e.Id).HasColumnName("WebsitePermissionId");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModificationDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.HasOne(d => d.ActiveDirectoryGroup)
                    .WithMany(p => p.WebsitePermissionCollection)
                    .HasForeignKey(d => d.ActiveDirectoryGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebsitePermission_ActiveDirectoryGroup");

                entity.HasOne(d => d.WebsiteInfo)
                    .WithMany(p => p.WebsitePermissionCollection)
                    .HasForeignKey(d => d.WebsiteInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebsitePermission_Website");
            });

            modelBuilder.Entity<WebsiteNavigationMenu>(entity =>
            {
                entity.ToTable("WebsiteNavigationMenu", "dbo");

                entity.HasKey(e => new { e.WebsiteInfoId, e.NavigationMenuId });

                entity.HasOne(d => d.NavigationMenu)
                    .WithMany(p => p.WebsiteNavigationMenuCollection)
                    .HasForeignKey(d => d.NavigationMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebsiteNavigationMenu_NavigationMenu");

                entity.HasOne(d => d.WebsiteInfo)
                    .WithMany(p => p.WebsiteNavigationMenuCollection)
                    .HasForeignKey(d => d.WebsiteInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebsiteNavigationMenu_Website");
            });

            base.OnModelCreating(modelBuilder);
            /*Seed the DB*/
            WebDbContextBuilderExtensions.Seed(modelBuilder);
        }


    }
}

