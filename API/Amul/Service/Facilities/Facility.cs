using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.Facilities
{
    public class Facility : IFacilities
    {
        readonly PlantVisitDBContext dbContext;
        public Facility(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }
        public async Task<int> Add(FacilitiesModel objFac)
        {
            using (var connection = dbContext)
            {
                await dbContext.Facilities.AddAsync(objFac);
                dbContext.SaveChanges();
            }
            return (int)objFac.FacilitiesId;
        }
        public async Task<bool> Update(FacilitiesModel objFac)
        {
            var facility = dbContext.Facilities.Find(objFac.FacilitiesId);
            if (facility == null)
                return false;

            await dbContext.SaveChangesAsync();
            return true;
        }



        public List<FacilitiesModel> GetAll()
        {
            List<FacilitiesModel> lstdata = new List<FacilitiesModel>();
            using (var connection = dbContext)
            {
                lstdata = dbContext.Facilities.ToList();
            }
            return lstdata;
        }
    }
}
