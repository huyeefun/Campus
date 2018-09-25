using Campus.Domain;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Dal
{
    public class CampusDbContext : DbContext
    {
        public CampusDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(x => x.Id);
                entity.HasAlternateKey(x => x.UserName);
                entity.Property(x => x.UserName).IsRequired().HasMaxLength(20);
                entity.Property(x => x.Password).IsRequired().HasMaxLength(2000);
            });
        }
    }
}
