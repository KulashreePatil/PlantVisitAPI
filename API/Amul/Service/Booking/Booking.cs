using Microsoft.EntityFrameworkCore;
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
        //public async Task<int> Add(Bookingmodel objbooking)
        //{
        //    await dbContext.Set<Bookingmodel>().AddAsync(objbooking);
        //    return await dbContext.SaveChangesAsync();
        //}
        public async Task<Bookingmodel> GetById(int id)
        {
            var booking = await dbContext.Set<Bookingmodel>().FindAsync(id);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Plant with ID {id} not found.");
            }
            return booking;
        }
        public async Task<int> Add(Bookingmodel objbooking)
        {
            var existingBooking = new Bookingmodel
            {
                UserID = objbooking.UserID,
                PlantID = objbooking.PlantID,
                VisitID = objbooking.VisitID,
                BookingDate = objbooking.BookingDate,
                Capacity = objbooking.Capacity
            };

            dbContext.BookingTable.Add(existingBooking);
            await dbContext.SaveChangesAsync();
            return (int)objbooking.BookingID;
        }

        public async Task<bool> Update(Bookingmodel objbooking)
        {
            if (objbooking.BookingID == null)
            {
                return false;  
            }

            Bookingmodel? existingBooking = await GetById((int)objbooking.BookingID);
            if (existingBooking != null)
            {
                existingBooking.BookingDate = objbooking.BookingDate;
                existingBooking.Capacity = objbooking.Capacity;

                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Bookingmodel>> GetAll()
        {
            return await dbContext.Set<Bookingmodel>().ToListAsync();
        }
    }
}
