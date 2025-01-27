using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.Plant
{
    public interface IPlantList
    {

        List<PlantListModel> GetAll();
        Task <int> Add(PlantListModel Plantlistmodel);
        Task <bool> Update (PlantListModel Plantlistmodel);
    }

}

