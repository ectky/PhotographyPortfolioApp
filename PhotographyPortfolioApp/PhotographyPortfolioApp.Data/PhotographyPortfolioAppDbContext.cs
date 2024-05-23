using Microsoft.EntityFrameworkCore;
using PhotographyPortfolioApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Data
{
    public class PhotographyPortfolioAppDbContext : DbContext
    {
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoGallery> PhotoGalleries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public PhotographyPortfolioAppDbContext(DbContextOptions<PhotographyPortfolioAppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gallery>()
                .HasMany(b => b.PhotoGalleries)
                .WithOne(p => p.UserId)
                .HasForeignKey(p => p.PhotographerId);
        }
    }
}
