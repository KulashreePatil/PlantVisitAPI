using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.Plant
{
    public interface IPlant
    {

       Task <APIResponseModel> GetAll();
        Task <APIResponseModel> Add(PlantModel objmodel);
        Task <APIResponseModel> Update (PlantModel objplant);
        Task <PlantModel> GetByID (int id);
    }

}

