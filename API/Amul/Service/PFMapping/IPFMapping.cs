using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.PFMap

{
    public interface IPFMapping
    {

        Task<APIResponseModel> GetAll();
        Task<PFMappingmodel?> GetByIdAsync(int? plantid);
        Task<APIResponseModel> Add(PFMappingmodel obj);
       

    }

}

