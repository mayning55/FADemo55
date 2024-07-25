using FADemo.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FADemo.Models.Organization;
using FADemo.Models.FixedAsset;
using FADemo.Models.BaseInformation;

namespace FADemo.Models
{
    public class ApplicationDbContext : IdentityDbContext<ExtendIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customizing the ASP.NET Identity model and overriding the defaults if needed

            builder.Entity<IdentityUserRole<string>>()
                   .HasOne<IdentityRole>()
                   .WithMany()
                   .HasForeignKey(ur => ur.RoleId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<AssetCreateBase>()
                .HasMany(a => a.AssetUpdateDetails)
                .WithOne(b => b.AssetCreateBase)
                .HasForeignKey(b => b.AssetId);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<AssetStatus> AssetStatuses { get; set; }
        public DbSet<AssetPosition> AssetPositions { get; set; }
        public DbSet<AssetDeprmetHod> AssetDeprmetHods { get; set; }
        public DbSet<AssetAlterMode> AssetAlterModes { get; set; }
        public DbSet<AssetCreateBase> AssetCreateBases { get; set; }
        public DbSet<AssetUpdateDetail> AssetUpdateDetails { get; set; }
        public DbSet<AssetAttachment> AssetAttachments { get; set; }
    }
}
