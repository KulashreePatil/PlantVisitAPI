using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.Facilities
{
    public interface IFacilities
    {
        Task<APIResponseModel> GetAll();
        Task<FacilitiesModel> GetById(int? id);
        Task<APIResponseModel> Add(FacilitiesModel facilityobj);
        Task<APIResponseModel> Update(FacilitiesModel facilityobj);
        
    }

}

