using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.Facilities
{
    public interface IFacilities
    {
        
        List<FacilitiesModel> GetAll();
        Task<int> Add(FacilitiesModel facilityModel);
        Task<bool> Update(FacilitiesModel facilityModel);
    }

}

