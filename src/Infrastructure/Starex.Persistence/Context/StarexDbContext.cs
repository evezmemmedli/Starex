using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
using Starex.Domain.Entities.Base;
using Starex.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Persistence.Context
{
    public class StarexDbContext : DbContext
    {
        public StarexDbContext(DbContextOptions<StarexDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
