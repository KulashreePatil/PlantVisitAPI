using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.Booking
{
    public interface IBooking
    {


        Task<List<Bookingmodel>> GetAll();

        Task<Bookingmodel> GetById(int id);
        Task<int> Add(Bookingmodel objbooking);
        Task<bool> Update(Bookingmodel objbooking);
    }

}

