using Microsoft.EntityFrameworkCore;
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
        public async Task<int> Add(FacilitiesModel objfac)
        {
            await dbContext.Set<FacilitiesModel>().AddAsync(objfac);
            return await dbContext.SaveChangesAsync();
        }
        public async Task<FacilitiesModel> GetById(int id)
        {
            return await dbContext.Set<FacilitiesModel>().FindAsync(id);
        }
        public async Task<bool> Update(FacilitiesModel objfac)
        {
            FacilitiesModel? existingfacility = await GetById((int)objfac.FacilitiesId);
            if (existingfacility != null)
            {
                existingfacility.FacilitiesName = objfac.FacilitiesName;


                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<FacilitiesModel>> GetAll()
        {
            return await dbContext.Facilities.ToListAsync();
        }

        public async Task<FacilitiesModel?> GetByIdAsync(int id)
        {
            return await dbContext.Facilities.FindAsync(id);
        }
        public async Task<List<PlantFacilityViewModel>> GetDetails()
        {
            return await dbContext.PlantFacilityViewModel.FromSqlRaw(@"SELECT p.PlantID, p.PlantName, f.FacilitiesId AS FacilityID, f.FacilitiesName 
                              FROM Plants p
                              INNER JOIN Mapping m ON p.PlantID = m.PlantID
                              INNER JOIN Facilities f ON m.FacilitiesID = f.FacilitiesId")
                .ToListAsync();
        }
    }
}
