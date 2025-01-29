using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.Facilities
{
    public interface IFacilities
    {
        Task<List<FacilitiesModel>> GetAll();
        Task<FacilitiesModel?> GetByIdAsync(int id);
        Task<int> Add(FacilitiesModel facilityobj);
        Task<bool> Update(FacilitiesModel facilityobj);
        Task<List<PlantFacilityViewModel>>GetDetails();
    }

}

