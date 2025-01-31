using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.Facilities
{
    public interface IFacilities
    {
        Task<APIResponseModel> GetAll();
        Task<FacilitiesModel?> GetByIdAsync(int id);
        Task<APIResponseModel> Add(FacilitiesModel facilityobj);
        Task<bool> Update(FacilitiesModel facilityobj);
        Task<List<PlantFacilityViewModel>>GetDetails();
    }

}

