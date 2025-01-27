using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.Plant
{
    public class PlantList:IPlantList
    {
        readonly PlantVisitDBContext dbContext;
    }
}
