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
            public DbSet<PFMapping> Mapping { get; set; }   
            public DbSet<PlantListModel> Plant { get; set; }
            public DbSet<UserData> UserData { get; set; }
            public DbSet<VisitSlotModel> VisitSlot { get; set; }
        public object PlantList { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingTable>().ToTable("BookingTable");
            modelBuilder.Entity<FacilitiesModel>().ToTable("Facilities");
            modelBuilder.Entity<PFMapping>().ToTable("PFMapping");
            modelBuilder.Entity<PlantListModel>().ToTable("PlantList");
            modelBuilder.Entity<UserData>().ToTable("UserData");
            modelBuilder.Entity<VisitSlotModel>().ToTable("VisitSlot");
        }
        }
    }


