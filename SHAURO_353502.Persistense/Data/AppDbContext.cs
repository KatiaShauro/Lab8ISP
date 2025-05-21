using Microsoft.EntityFrameworkCore;


namespace SHAURO_353502.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated(); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .OwnsOne<ServiceSchedule>(t => t.Schedule);

        }

    }
}
