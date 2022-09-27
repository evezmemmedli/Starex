using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
using Starex.Domain.Entities.Base;
using Starex.Domain.Entities.Logging;

namespace Starex.Persistence.Context
{
    public class StarexDbContext : IdentityDbContext<AppUser>
    {
        public StarexDbContext(DbContextOptions<StarexDbContext> opt) : base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasOne(x => x.PoctAdress).WithMany(x => x.AppUsers)
                .HasForeignKey(x=>x.PoctAdressId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AppUser>().HasOne(x => x.DeliveryPoint).WithMany(x => x.AppUsers)
                .HasForeignKey(x=>x.DeliveryPointId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.ApplyConfiguration(new AboutConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new AdvantageConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new FaqConfiguration());
            modelBuilder.ApplyConfiguration(new FaqQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new AboutSkillConfiguration());
            modelBuilder.ApplyConfiguration(new PoctAdressConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryPointConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<FaqQuestion> FaqQuestions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<AboutSkill> AboutSkills { get; set; }
        public DbSet<PoctAdress> PoctAdresses { get; set; }
        public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public DbSet<ActionLog> ActionLogs { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Commitment> Commitments { get; set; }
        public DbSet<Declare> Declares { get; set; }
        public DbSet<ReturnPackage> ReturnPackages { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow.AddHours(4);
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        
    }
}
