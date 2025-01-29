using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PlantVisit.Service.PFMap
{
    public class PFMapping : IPFMapping
    {
        readonly PlantVisitDBContext dbContext;
        public PFMapping(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }

        public async Task<int> Add(PFMappingmodel objMapping)
        {
            var existingPFMapping = new PFMappingmodel
            {
                PlantID = objMapping.PlantID,
                FacilitiesID = objMapping.FacilitiesID

            };
            dbContext.Mapping.Add(existingPFMapping);
            await dbContext.SaveChangesAsync();
            return existingPFMapping.PFId;

            
        }

        public async Task<List<PFMappingmodel>> GetAll()
        {
            return await dbContext.Mapping.ToListAsync();
        }

        public async Task<PFMappingmodel?> GetByIdAsync(int plantid)
        {
            return await dbContext.Mapping.FirstOrDefaultAsync(m => m.PlantID == plantid);
        }

        public async Task<List<PlantFacilityViewModel>> GetDetails()
        {
            return await dbContext.ViewModel
                .FromSqlRaw(@"
                    SELECT 
                        p.PlantID, 
                        p.PlantName, 
                        f.FacilitiesId AS FacilityID, 
                        f.FacilitiesName AS FacilityName
                    FROM Plants p
                    INNER JOIN Mapping m ON p.PlantID = m.PlantID
                    INNER JOIN Facilities f ON m.FacilitiesID = f.FacilitiesId
                ")
                .ToListAsync();
        }
    }
}
