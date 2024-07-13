using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace My_Uber.Context.Context
{
    public class MyUberDbContext : IdentityDbContext<User>
    {
        public MyUberDbContext(DbContextOptions<MyUberDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}