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
            var existingFacilities = new FacilitiesModel
            {
                FacilitiesName = objfac.FacilitiesName,
            };

            dbContext.Facilities.Add(existingFacilities);
            await dbContext.SaveChangesAsync();
            return (int)objfac.FacilitiesId;
        }
        public async Task<FacilitiesModel> GetById(int id)
        {
            var facilities = await dbContext.Set<FacilitiesModel>().FindAsync(id);
            if (facilities == null)
            {
                throw new KeyNotFoundException($"Facilities with ID {id} not found.");
            }
            return facilities;
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
