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

        public DbSet<ContentType> ContentTypes { get; set; }
    }
}
