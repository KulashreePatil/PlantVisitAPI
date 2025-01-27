using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
namespace PlantVisit.EFCoreModel
{
        public class PlantVisitDBContext : DbContext
        {

        public PlantVisitDBContext(DbContextOptions<PlantVisitDBContext> options) : base(options)
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
            public DbSet<FacilitiesModel> Facilities { get; set; }
            public DbSet<PFMappingmodel> PFMappingmodel { get; set; }   
            public DbSet<PlantList> Plants { get; set; }
            public DbSet<UserDatamodel> UserDatamodel { get; set; }
            public DbSet<VisitSlot> VisitSlot { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingTable>().ToTable("BookingTable");
            modelBuilder.Entity<FacilitiesModel>().ToTable("Facilities");
            modelBuilder.Entity<PFMappingmodel>().ToTable("PFMapping");
            modelBuilder.Entity<PlantList>().ToTable("PlantList");
            modelBuilder.Entity<UserDatamodel>().ToTable("UserData");
            modelBuilder.Entity<VisitSlot>().ToTable("VisitSlot");
        }
        }
    }


