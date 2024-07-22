using Microsoft.EntityFrameworkCore;
using Models;

namespace My_Uber.Context.Context
{
    public class MyUberDbContext : DbContext
    {
        public MyUberDbContext(DbContextOptions<MyUberDbContext> options) : base(options) { }

        // DbSet for the Building entity
        public DbSet<BuildingModel> Buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Building entity
            modelBuilder.Entity<BuildingModel>(entity =>
            {
                entity.ToTable("Buildings"); // Optional: specify the table name
                entity.HasKey(b => b.Id); // Specify the primary key
                entity.Property(b => b.BuildingName).IsRequired().HasMaxLength(100);
                entity.Property(b => b.BuildingNumber).IsRequired().HasMaxLength(50);
                entity.Property(b => b.NumberOfFloors).IsRequired();
                entity.Property(b => b.BuildingType).IsRequired().HasMaxLength(50);
                entity.Property(b => b.AdditionalData).HasMaxLength(255);
                entity.Property(b => b.CreatedDate).IsRequired();
            });

            
        }
    }
}
