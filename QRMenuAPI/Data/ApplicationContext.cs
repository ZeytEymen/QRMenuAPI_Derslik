using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QRMenuAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace QRMenuAPI.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<State>? States { get; set; }
        public DbSet<Restaurant>? Restaurants { get; set; }
        public DbSet<RestaurantUser>? RestaurantUsers { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Restaurant>().HasOne(r => r.State).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RestaurantUser>().HasKey(r => new { r.RestaurantId, r.UserId });
            modelBuilder.Entity<RestaurantUser>().HasOne(r => r.Restaurant).WithMany().OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}

