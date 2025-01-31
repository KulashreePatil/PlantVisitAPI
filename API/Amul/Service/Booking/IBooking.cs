using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.Booking
{
    public interface IBooking
    {


        Task<APIResponseModel> GetAll();

        Task<Bookingmodel> GetById(int? id);
        Task<APIResponseModel> Add(Bookingmodel objbooking);
        Task<APIResponseModel> Update(Bookingmodel objbooking);
    }

}

