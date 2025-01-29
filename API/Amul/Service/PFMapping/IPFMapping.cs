using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.PFMap

{
    public interface IPFMapping
    {

        Task<List<PFMappingmodel>> GetAll();
        Task<PFMappingmodel?> GetByIdAsync(int plantid);
        Task<int> Add(PFMappingmodel obj);
        Task<List<PlantFacilityViewModel>> GetDetails();

    }

}

