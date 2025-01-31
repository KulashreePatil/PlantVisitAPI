using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.PFMap
{
    public class PFMapping : IPFMapping
    {
        readonly PlantVisitDBContext dbContext;
        public PFMapping(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }
        public async Task<APIResponseModel> Add(PFMappingmodel objMapping)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                var existingPFMapping = new PFMappingmodel
                {
                    PlantID = objMapping.PlantID,
                    FacilitiesID = objMapping.FacilitiesID
                };

                dbContext.Mapping.Add(existingPFMapping);
                await dbContext.SaveChangesAsync();
                response.Data = (int)objMapping.PFId;
                response.Message = "record added successfully";
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong";
                response.Data = 0;
            }
            return response;
        }
      
        public async Task<APIResponseModel> GetAll()
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                response.Data = await dbContext.Mapping.ToListAsync();
                response.Message = "record fetched successfully";
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = "Something went wrong";
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<PFMappingmodel?> GetByIdAsync(int? plantid)
        {
            return await dbContext.Mapping.FirstOrDefaultAsync(m => m.PlantID == plantid);
        }

      
    }
}
