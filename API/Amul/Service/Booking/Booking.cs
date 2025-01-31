using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.Booking
{
    public class Booking : IBooking
    {
        readonly PlantVisitDBContext dbContext;
        public Booking(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }
        
        public async Task<Bookingmodel> GetById(int? id)
        {
            var booking = await dbContext.Set<Bookingmodel>().FindAsync(id);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Plant with ID {id} not found.");
            }
            return booking;
        }
        public async Task<APIResponseModel> Add(Bookingmodel objbooking)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                var existing = new Bookingmodel
                {
                    UserID = objbooking.UserID,
                    PlantID = objbooking.PlantID,
                    VisitID = objbooking.VisitID,
                    BookingDate = objbooking.BookingDate,
                    Capacity = objbooking.Capacity
                };

                dbContext.BookingTable.Add(existing);
                await dbContext.SaveChangesAsync();
                response.Data = (int)objbooking.BookingID;
                response.Message = "record added successfully";
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong";
                response.Data = 0;
            }
            return response;
        }
        
        public async Task<APIResponseModel> Update(Bookingmodel objbooking)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {

                Bookingmodel? existingbooking = await GetById(objbooking.BookingID);
                if (existingbooking != null)
                {
                    existingbooking.Capacity = objbooking.Capacity;
                    existingbooking.BookingDate = objbooking.BookingDate;
                    response.Data = await dbContext.SaveChangesAsync();
                    response.Message = "record fetched successfully";
                    response.IsSuccess = true;

                }
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Message = "Something went wrong";
                response.IsSuccess = false;

            }
            return response;
        }

        public async Task<APIResponseModel> GetAll()
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                response.Data = await dbContext.BookingTable.ToListAsync();
                response.Message = "record fetched successfully";
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = "Something went wrong";
                response.IsSuccess = false;
            }
            return response;
        }
        
        
    }
}
