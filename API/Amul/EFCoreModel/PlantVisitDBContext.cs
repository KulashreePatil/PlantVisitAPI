using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using PlantVisit.EFCoreModel;
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

            public DbSet<Bookingmodel> BookingTable { get; set; }
            public DbSet<FacilitiesModel> Facilities { get; set; }
            public DbSet<PFMappingmodel> Mapping { get; set; }   
            public DbSet<PlantListModel> Plant { get; set; }
            public DbSet<UserDatamodel> UserData { get; set; }
            public DbSet<VisitSlotModel> VisitSlot { get; set; }
        public DbSet<PlantFacilityViewModel> PlantFacilityViewModel { get; set; }
        public DbSet<PlantFacilityViewModel> ViewModel { get; set; }
        public object PlantList { get; internal set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookingmodel>().ToTable("BookingTable");
            modelBuilder.Entity<FacilitiesModel>().ToTable("Facilities");
            modelBuilder.Entity<PFMappingmodel>().ToTable("PFMapping");
            modelBuilder.Entity<PlantListModel>().ToTable("PlantList");
            modelBuilder.Entity<UserDatamodel>().ToTable("UserData");
            modelBuilder.Entity<VisitSlotModel>().ToTable("VisitSlot");
            modelBuilder.Entity<PlantFacilityViewModel>().HasNoKey();
        }
        }
    }


