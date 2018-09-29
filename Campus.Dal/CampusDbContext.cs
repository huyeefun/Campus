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
        public DbSet<Role> Roles { set; get; }
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
                entity.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId).HasConstraintName("ForeignKey_User_Role");
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
                entity.HasAlternateKey(x => x.Name);
                entity.Property(x => x.Name).HasMaxLength(50).IsRequired();
            });
        }
    }
}
