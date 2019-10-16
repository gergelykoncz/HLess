using HLess.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HLess.Data
{
    public class HLessDataContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public HLessDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AccountUser>().HasKey(au => new { au.AccountId, au.UserId });
            builder.Entity<AccountUser>().HasOne(au => au.Account).WithMany(a => a.AccountUsers).HasForeignKey(au => au.AccountId);
            builder.Entity<AccountUser>().HasOne(au => au.User).WithMany(a => a.AccountUsers).HasForeignKey(au => au.UserId);
        }

        public DbSet<ContentType> ContentTypes { get; set; }
    }
}
