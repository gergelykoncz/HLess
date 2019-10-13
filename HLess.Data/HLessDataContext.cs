using HLess.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HLess.Data
{
    public class HLessDataContext : IdentityDbContext<ApplicationUser>
    {
        public HLessDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
