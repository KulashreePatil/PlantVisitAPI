using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.Plant
{
    public interface IPlant
    {
        Task<APIResponseModel> GetAll(string? searchTerm);
        Task<PlantModel> GetByID(int id);
        Task<APIResponseModel> Add(PlantModel objplant);
        Task<APIResponseModel> Update(PlantModel objplant);
    }


}

