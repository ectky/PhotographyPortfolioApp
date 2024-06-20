using Microsoft.EntityFrameworkCore;
using PhotographyPortfolioApp.Data.Entities;
using PhotographyPortfolioApp.Shared.Enums;
using PhotographyPortfolioApp.Shared.Security;
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

        public PhotographyPortfolioAppDbContext()
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(b => b.UploadedPhotos)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>()
               .HasMany(u => u.Galleries)
               .WithOne(u => u.User)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Photo>()
               .HasMany(u => u.Tags)
               .WithOne(u => u.Photo)
               .HasForeignKey(p => p.PhotoId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
               .HasMany(u => u.Users)
               .WithOne(u => u.Role)
               .HasForeignKey(p => p.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

            foreach (var role in Enum.GetValues(typeof(UserRole)).Cast<UserRole>())
            {
                modelBuilder.Entity<Role>().HasData(new Role { Id = (int)role, Name = role.ToString() });
            }

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Username = "admin",
                    RoleId = (int)UserRole.Admin,
                    FirstName = "Admin",
                    LastName = "User",
                    Password = PasswordHasher.HashPassword("string")

                });
        }
    }
}
