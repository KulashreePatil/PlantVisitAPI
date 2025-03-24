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
        //public async Task<APIResponseModel> Add(Bookingmodel objbooking)
        //{
        //    APIResponseModel response = new APIResponseModel();
        //    try
        //    {
        //        var existing = new Bookingmodel
        //        {
        //            UserID = objbooking.UserID,
        //            PlantID = objbooking.PlantID,
        //            VisitID = objbooking.VisitID,
        //            BookingDate = objbooking.BookingDate,
        //            Capacity = objbooking.Capacity
        //        };

        //        dbContext.BookingTable.Add(existing);
        //        await dbContext.SaveChangesAsync();
        //        response.Data = (int)objbooking.BookingID;
        //        response.Message = "record added successfully";
        //        response.IsSuccess = true;
        ////    }
        //    catch (Exception e)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = "Something went wrong";
        //        response.Data = 0;
        //    }
        //    return response;
        //}
        public async Task<APIResponseModel> Add(Bookingmodel objbooking)
        {
            APIResponseModel response = new APIResponseModel();

            try
            {
                // 1. Basic validation (date, capacity, etc.)
                if (objbooking.BookingDate == default(DateTime))
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid booking date.";
                    return response;
                }

                // 2. Fetch the related Visit from the database
                var visit = await dbContext.Visit.FindAsync(objbooking.VisitID);
                if (visit == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Visit not found.";
                    return response;
                }

                // 3. Check if capacity is exceeded for the entered PlantID only
                int totalBookedForThisVisit = await dbContext.BookingTable
                    .Where(b => b.VisitID == objbooking.VisitID && b.PlantID == objbooking.PlantID)
                    .SumAsync(b => (int?)b.Capacity) ?? 0;

                // Ensure the new booking does not exceed the visit's capacity for this PlantID
                if (totalBookedForThisVisit + objbooking.Capacity > visit.Capacity)
                {
                    response.IsSuccess = false;
                    response.Message = $"Cannot book. Capacity exceeded for Visit {visit.VisitID} at Plant {objbooking.PlantID}.";
                    return response;
                }

                // 4. If capacity is still available, create the booking
                dbContext.BookingTable.Add(objbooking);
                await dbContext.SaveChangesAsync();

                // 5. Return success
                response.Data = (int)objbooking.BookingID;
                response.IsSuccess = true;
                response.Message = "Booking created successfully.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong while creating the booking.";
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
