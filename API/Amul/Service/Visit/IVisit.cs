using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.Visit
{
    public interface IVisit
    {

        Task <APIResponseModel> GetAll();
        Task<APIResponseModel> Add(VisitModel objvisit);
        Task<APIResponseModel> Update(VisitModel objvisit);
        Task<VisitModel> GetByID(int id);
    }

}

