using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.PFMap
{
    public class PFMap : IPFMapping
    {
        readonly PlantVisitDBContext dbContext;
        public PFMap(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }
        


        public List<PFMappingmodel> GetAll()
        {
            List<PFMappingmodel> lstdata = new List<PFMappingmodel>();
            using (var connection = dbContext)
            {
                lstdata = dbContext.PFMappingmodel.ToList();
            }
            return lstdata;
        }
    }
}
