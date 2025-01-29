using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.Visit
{
    public interface IVisit
    {

        Task <List<VisitModel>> GetAll();
        Task<int> Add(VisitModel objvisit);
        Task<bool> Update(VisitModel objvisit);
        Task<VisitModel> GetByID(int id);
    }

}

