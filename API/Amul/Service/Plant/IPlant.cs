using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.Plant
{
    public interface IPlant
    {

       Task <List<PlantModel>> GetAll();
        Task <int> Add(PlantModel objmodel);
        Task <bool> Update (PlantModel objplant);
        Task <PlantModel> GetByID (int id);
    }

}

