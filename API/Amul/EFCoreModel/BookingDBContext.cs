using Microsoft.EntityFrameworkCore;

namespace PlantVisit.EFCoreModel
{
    
    
        public class BookingDBContext : DbContext
        {
            public BookingDBContext(DbContextOptions<BookingDBContext> options) : base(options)
            {

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false)
           .Build();

                string? connection = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connection);
            }

            public DbSet<BookingTable> BookingTable { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<BookingTable>().ToTable("BookingTable");

            }
        }
    }


