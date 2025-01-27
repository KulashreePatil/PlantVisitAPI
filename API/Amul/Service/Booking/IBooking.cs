using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.Booking
{
    public interface IBooking
    {

        List<BookingTable> GetAll();
        Task<int> Add(BookingTable objbooking);
        Task<bool> Update(BookingTable objbooking);
    }

}

