using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.Booking
{
    public class Booking : IBooking
    {
        readonly PlantVisitDBContext dbContext;
        public Booking(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }
        public async Task<int> Add(BookingTable objbooking)
        {
            using (var connection = dbContext)
            {
                await dbContext.BookingTable.AddAsync(objbooking);
                dbContext.SaveChanges();
            }
            return (int)objbooking.BookingID;
        }
        public async Task<bool> Update(BookingTable objbooking)
        {
            var facility = dbContext.BookingTable.Find(objbooking.BookingID);
            if (facility == null)
                return false;

            await dbContext.SaveChangesAsync();
            return true;
        }



        public List<BookingTable> GetAll()
        {
            List<BookingTable> lstdata = new List<BookingTable>();
            using (var connection = dbContext)
            {
                lstdata = dbContext.BookingTable.ToList();
            }
            return lstdata;
        }
    }
}
