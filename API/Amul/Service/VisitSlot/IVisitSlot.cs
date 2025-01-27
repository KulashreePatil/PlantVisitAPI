using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.VisitSlot
{
    public interface IVisitSlot
    {

        List<VisitSlotModel> GetAll();
        Task<int> Add(VisitSlotModel VisitSlotModel);
        Task<bool> Update(VisitSlotModel VisitSlotModel);
    }

}

